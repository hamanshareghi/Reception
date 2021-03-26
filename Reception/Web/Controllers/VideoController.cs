using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Controllers
{
    //[Area("Admin")]
    public class VideoController : Controller
    {
        private IVideo _video;

        public VideoController(IVideo video)
        {
            _video = video;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _video.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _video.GetById(id.Value);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoId,Title,Link,Description,InsertDate,IsDelete,UpDateTime")] Video video)
        {
            if (ModelState.IsValid)
            {
                video.InsertDate = DateTime.Now;
                video.UpDateTime=DateTime.Now;
                _video.Add(video);

                return RedirectToAction(nameof(Index), "Video");
            }
            return View(video);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _video.GetById(id.Value);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoId,Title,Link,Description,InsertDate,IsDelete,UpDateTime")] Video video)
        {
            if (id != video.VideoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    video.UpDateTime = DateTime.Now;
                    _video.Update(video);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.VideoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Video");
            }
            return View(video);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _video.GetById(id.Value);

            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var video = await _video.GetById(id);
            _video.Delete(video);

            return RedirectToAction(nameof(Index), "Video");
        }

        private bool VideoExists(int id)
        {
            return _video.Exist(id);
        }
    }
}
