using System;
using System.IO;
using System.Threading.Tasks;
using Common.Library;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admins,SuperAdmin")]
    [Area("Admin")]
    //[Authorize]
    public class ProductsController : Controller
    {
        private IProduct _product;

        private IBrand _brand;
        private IProductGroup _productgroup;

        public ProductsController(IProduct product, IBrand brand, IProductGroup productGroup)
        {
            _product = product;
            _brand = brand;
            _productgroup = productGroup;
        }

        // GET: Admin/Products
        public IActionResult Index(string search,int take,int pageId=1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_product.GetProductBySearch(search,25, pageId = 1));
            }

            return View(_product.GetAll(25,pageId));
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _product.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["ProductGroupId"] = new SelectList(_productgroup.GetAll(), "ProductGroupId", "GroupName");
            ViewData["BrandId"] = new SelectList(_brand.GetAll(0), "BrandId", "Title");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductGroupId,InsertDate,ParentId,Name,Price,Warranty,ShortText,Image,BrandId,IsDelete,UpdateTime")] Product product,IFormFile imgUp)
        {
            if (ModelState.IsValid)
            {
                product.Image = "No-Photo.png";
                
                //TODO Check Image
                if (imgUp != null )
                {
                    product.Image = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgUp.FileName);
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Products/", product.Image);

                    await using var stream = new FileStream(imagePath, FileMode.Create);
                    await imgUp.CopyToAsync(stream);
                }

                product.InsertDate=DateTime.Now;
                product.UpDateTime=DateTime.Now;
                //product.ShortKey = GenerateShortKey(4);
                _product.Add(product,imgUp);
                return RedirectToAction(nameof(Index),"Products");
            }
            ViewData["ProductGroupId"] = new SelectList(_productgroup.GetAll(), "ProductGroupId", "GroupName");
            ViewData["BrandId"] = new SelectList(_brand.GetAll(0), "BrandId", "Title");
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _product.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductGroupId"] = new SelectList(_productgroup.GetAll(), "ProductGroupId", "GroupName");
            ViewData["BrandId"] = new SelectList(_brand.GetAll(0), "BrandId", "Title");
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductGroupId,InsertDate,ParentId,Name,Price,Warranty,ShortText,Image,BrandId,IsDelete,UpdateTime")] Product product,IFormFile imgUp)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                 
                    if (imgUp != null)
                    {

                        var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Products");
                        var saveName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgUp.FileName);
                        await using (var streamFile = new FileStream(Path.Combine(savePath, saveName), FileMode.Create))
                            await imgUp.CopyToAsync(streamFile);
                        product.Image = saveName;
                    }
                    product.UpDateTime=DateTime.Now;
                    _product.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Products");
            }
            ViewData["ProductGroupId"] = new SelectList(_productgroup.GetAll(), "ProductGroupId", "GroupName");
            ViewData["BrandId"] = new SelectList(_brand.GetAll(0), "BrandId", "Title");
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _product.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = _product.GetById(id);
            _product.Delete(product);
            return RedirectToAction(nameof(Index),"Products");
        }

        private bool ProductExists(int id)
        {
            return _product.Exist(id);
        }
        //private string GenerateShortKey(int length = 0)
        //{
        //    var shortKey = Guid.NewGuid().ToString().Trim().Replace("-", "").Substring(0, length);
        //    if (_product.ShortKeyExist(shortKey))
        //    {
        //        shortKey = Guid.NewGuid().ToString().Trim().Replace("-", "").Substring(0, length);
        //    }

        //    return shortKey;
        //}
    }
}
