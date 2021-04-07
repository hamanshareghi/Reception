using System;
using System.IO;
using System.Threading.Tasks;
using Common.Library;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admins,SuperAdmin")]
    [Area("Admin")]
    public class CarouselsController : Controller
    {
        private ICarousel _carousel;

        public CarouselsController(ICarousel carousel)
        {
            _carousel = carousel;
        }

        // GET: Admin/Carousels
        public async Task<IActionResult> Index()
        {
            return View(_carousel.GetAllSlider());
        }

        // GET: Admin/Carousels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = _carousel.GetSliderById(id.Value);
            if (carousel == null)
            {
                return NotFound();
            }

            return View(carousel);
        }

        // GET: Admin/Carousels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Carousels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Caption,ImageName,LinkPage,Id,InsertDate,IsDelete,UpDateTime")] Carousel carousel,IFormFile imgUp)
        {
            if (ModelState.IsValid)
            {
                carousel.ImageName = "No-Photo.Png";

                //TODO Check Image
                if (imgUp != null)
                {
                    carousel.ImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgUp.FileName);
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Carousel/", carousel.ImageName);

                    await using var stream = new FileStream(imagePath, FileMode.Create);
                    await imgUp.CopyToAsync(stream);
                }

                carousel.InsertDate=DateTime.Now;
                carousel.UpDateTime=DateTime.Now;
                _carousel.AddSlider(carousel);
                
                return RedirectToAction(nameof(Index),"Carousels",new {area="Admin"});
            }
            return View(carousel);
        }

        // GET: Admin/Carousels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = _carousel.GetSliderById(id.Value);
            if (carousel == null)
            {
                return NotFound();
            }
            return View(carousel);
        }

        // POST: Admin/Carousels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Caption,ImageName,LinkPage,Id,InsertDate,IsDelete,UpDateTime")] Carousel carousel,IFormFile imgUp)
        {
            if (id != carousel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imgUp != null)
                    {
                        if (carousel.ImageName != null)
                        {
                            var oldImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Carousel/",
                                carousel.ImageName);
                            if (System.IO.File.Exists(oldImage))
                            {
                                System.IO.File.Delete(oldImage);
                            }
                        }
                        carousel.ImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgUp.FileName);
                        var imgAddress = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Carousel/",
                            carousel.ImageName);
                        await using var stream = new FileStream(imgAddress, FileMode.Create);
                        await imgUp.CopyToAsync(stream);


                    }
                    carousel.UpDateTime=DateTime.Now;
                    _carousel.UpdateSlider(carousel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarouselExists(carousel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),"Carousels" , new {area="Admin"});
            }
            return View(carousel);
        }

        // GET: Admin/Carousels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = _carousel.GetSliderById(id.Value);
            if (carousel == null)
            {
                return NotFound();
            }

            return View(carousel);
        }

        // POST: Admin/Carousels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carousel = _carousel.GetSliderById(id);
            carousel.IsDelete = true;
            _carousel.UpdateSlider(carousel);
            return RedirectToAction(nameof(Index),"Carousels",new {area="Admin"});
        }

        private bool CarouselExists(int id)
        {
            return _carousel.SliderExists(id);
        }
    }
}
