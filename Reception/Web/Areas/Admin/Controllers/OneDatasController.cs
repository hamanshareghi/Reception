using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admins,SuperAdmin")]
    [Area("Admin")]

    public class OneDatasController : Controller
    {
        private IOneData _oneData;

        public OneDatasController(IOneData oneData)
        {
            _oneData = oneData;
        }

        // GET: Admin/OneDatas
        public async Task<IActionResult> Index()
        {
            return View(_oneData.GetAll());
        }

        // GET: Admin/OneDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oneData = _oneData.GetById(id.Value);
            if (oneData == null)
            {
                return NotFound();
            }

            return View(oneData);
        }

        // GET: Admin/OneDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/OneDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Introduction,SiteRules,Privacy,SiteAddress")] OneData oneData)
        {
            if (ModelState.IsValid)
            {
                oneData.InsertDate=DateTime.Now;
                oneData.UpDateTime=DateTime.Now;
                _oneData.Add(oneData);
                return RedirectToAction(nameof(Index),"OneDatas");
            }
            return View(oneData);
        }

        // GET: Admin/OneDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oneData = _oneData.GetById(id.Value);
            if (oneData == null)
            {
                return NotFound();
            }
            return View(oneData);
        }

        // POST: Admin/OneDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Introduction,SiteRules,Privacy,SiteAddress")] OneData oneData)
        {
            if (id != oneData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    oneData.UpDateTime=DateTime.Now;
                   _oneData.Update(oneData);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OneDataExists(oneData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),"OneDatas",new {area="Admin"});
            }
            return View(oneData);
        }

        // GET: Admin/OneDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oneData = _oneData.GetById(id.Value);
            if (oneData == null)
            {
                return NotFound();
            }

            return View(oneData);
        }

        // POST: Admin/OneDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oneData = _oneData.GetById(id);
            _oneData.Delete(oneData);
            return RedirectToAction(nameof(Index),"OneDatas",new {area="Admin"});
        }

        private bool OneDataExists(int id)
        {
            return _oneData.Exist(id);
        }
    }
}
