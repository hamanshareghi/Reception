﻿using System;
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
    public class DefectController : Controller
    {
        private IDefect _defect;

        public DefectController(IDefect defect)
        {
            _defect = defect;
        }

        public IActionResult Index(string search,int take,int pageId=1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_defect.GetDefectBySearch(search, 25, pageId));
            }
            return View( _defect.GetAll(25,pageId));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defect = await _defect.GetById(id.Value);
            if (defect == null)
            {
                return NotFound();
            }

            return View(defect);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DefectId,Name,Description,InsertDate,IsDelete,UpDateTime")] Defect defect)
        {
            if (ModelState.IsValid)
            {

                defect.InsertDate = DateTime.Now;
                defect.UpDateTime=DateTime.Now;
                _defect.Add(defect);

                return RedirectToAction(nameof(Index), "Defect", new {area="Admin"});
            }
            return View(defect);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defect = await _defect.GetById(id.Value);
            if (defect == null)
            {
                return NotFound();
            }
            return View(defect);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DefectId,Name,Description,InsertDate,IsDelete,UpDateTime")] Defect defect)
        {
            if (id != defect.DefectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    defect.UpDateTime = DateTime.Now;
                    _defect.Update(defect);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefectExists(defect.DefectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Defect", new { area = "Admin" });
            }
            return View(defect);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defect = await _defect.GetById(id.Value);

            if (defect == null)
            {
                return NotFound();
            }

            return View(defect);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var defect = await _defect.GetById(id);
            _defect.Delete(defect);

            return RedirectToAction(nameof(Index), "Defect", new { area = "Admin" });
        }

        private bool DefectExists(int id)
        {
            return _defect.Exist(id);
        }

    }
}
