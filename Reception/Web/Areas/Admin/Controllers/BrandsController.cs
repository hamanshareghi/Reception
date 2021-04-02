using System;
using System.IO;
using System.Threading.Tasks;
using Common.Library;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class BrandsController : Controller
    {
        private IBrand _brand;

        public BrandsController(IBrand brand)
        {
            _brand = brand;
        }

        // GET: Admin/Brands
        public async Task<IActionResult> Index()
        {
            return View(_brand.GetAll(12));
        }

        // GET: Admin/Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = _brand.GetById(id.Value);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Admin/Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,Title,Image,Link,InsertDate,IsDelete,UpDateTime")] Brand brand, IFormFile imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    brand.Image = NameGenerator.GenerateUniqCode().ToString() + Path.GetExtension(imgUp.FileName);

                    string savePath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img/Brand/", brand.Image
                    );

                    await using var stream = new FileStream(savePath, FileMode.Create);
                    await imgUp.CopyToAsync(stream);


                }
                brand.InsertDate=DateTime.Now;
                brand.UpDateTime=DateTime.Now;
                _brand.Add(brand);
                return RedirectToAction(nameof(Index),"Brands");
            }
            return View(brand);
        }




        // GET: Admin/Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = _brand.GetById(id.Value);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandId,Title,Image,Link,InsertDate,IsDelete,UpDateTime")] Brand brand,IFormFile imgUp)
        {
            if (id != brand.BrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imgUp != null)
                    {
                        if (brand.Image != null)
                        {
                            var oldImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Brand/",
                                brand.Image);
                            if (System.IO.File.Exists(oldImage))
                            {
                                System.IO.File.Delete(oldImage);
                            }
                        }
                        brand.Image = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgUp.FileName);
                        var imgAddress = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Brand/",
                            brand.Image);
                        await using var stream = new FileStream(imgAddress, FileMode.Create);
                        await imgUp.CopyToAsync(stream);
                    }
                    brand.UpDateTime=DateTime.Now;
                    _brand.Update(brand);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.BrandId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Brands");

            }
            return View(brand);
        }

        // GET: Admin/Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = _brand.GetById(id.Value);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Admin/Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = _brand.GetById(id);
            
            _brand.Delete(brand);
            return RedirectToAction(nameof(Index), "Brands");

        }

        private bool BrandExists(int id)
        {
            return _brand.Exist(id);
        }
    }
}
