using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    //[Authorize(Roles = "SuperAdmin,Admins")]
    [Area("Admin")]
    public class FaqsController : Controller
    {
        private IFaq _faq;

        public FaqsController(IFaq faq)
        {
            _faq = faq;
        }


        // GET: Admin/Faqs
        public async Task<IActionResult> Index()
        {
            return View(_faq.GetAll());
        }

        // GET: Admin/Faqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = _faq.GetById(id.Value);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // GET: Admin/Faqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Faqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FaqId,FaqTitle,FaqAnswer,DateCreate,UserName")] Faq faq)
        {
            if (ModelState.IsValid)
            {
                faq.InsertDate = DateTime.Now;
                faq.UpDateTime=DateTime.Now;
                _faq.Add(faq);
                _faq.Save();
                return RedirectToAction(nameof(Index), "Faqs",new {area="Admin"});
            }
            return View(faq);
        }

        // GET: Admin/Faqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = _faq.GetById(id.Value);
            if (faq == null)
            {
                return NotFound();
            }
            return View(faq);
        }

        // POST: Admin/Faqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FaqId,FaqTitle,FaqAnswer,DateCreate,UserName")] Faq faq)
        {
            if (id != faq.FaqId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    faq.UpDateTime=DateTime.Now;
                    _faq.Update(faq);
                    _faq.Save();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaqExists(faq.FaqId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Faqs", new { area = "Admin" });

            }
            return View(faq);
        }

        // GET: Admin/Faqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = _faq.GetById(id.Value);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // POST: Admin/Faqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faq = _faq.GetById(id);
           _faq.Delete(faq);
           return RedirectToAction(nameof(Index), "Faqs", new { area = "Admin" });

        }

        private bool FaqExists(int id)
        {
            return _faq.Exist(id);
        }
    }
}
