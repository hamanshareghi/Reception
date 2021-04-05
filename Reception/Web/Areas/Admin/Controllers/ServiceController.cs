using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private IService _service;

        public ServiceController(IService service)
        {
            _service = service;
        }

        public IActionResult Index(string search,int take,int pageId=1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                return View(_service.GetServiceBySearch(search, 25, pageId));
            }
            return View(_service.GetAll(25,pageId));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _service.GetById(id.Value);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,Name,Warranty,Description,InsertDate,IsDelete,UpDateTime")] Service service)
        {
            if (ModelState.IsValid)
            {

                service.InsertDate = DateTime.Now;
                service.UpDateTime=DateTime.Now;
                //service.UserId = _userManager.GetUserId(User);

                _service.Add(service);

                return RedirectToAction(nameof(Index), "Service",new {area="Admin"});
            }
            return View(service);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _service.GetById(id.Value);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,Name,Warranty,Description,InsertDate,IsDelete,UpDateTime")] Service service)
        {
            if (id != service.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    service.UpDateTime = DateTime.Now;
                    _service.Update(service);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Service", new { area = "Admin" });
            }
            return View(service);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _service.GetById(id.Value);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _service.GetById(id);
            _service.Delete(service);

            return RedirectToAction(nameof(Index), "Service", new { area = "Admin" });
        }

        private bool ServiceExists(int id)
        {
            return _service.Exist(id);
        }
    }
}
