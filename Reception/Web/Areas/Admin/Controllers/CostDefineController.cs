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
    public class CostDefineController : Controller
    {
        private ICostDefine _costDefine;

        public CostDefineController(ICostDefine costDefine)
        {
            _costDefine = costDefine;
        }

        public IActionResult Index(string search,int take,int pageId=1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                return View(_costDefine.GetCostDefineBySearch(search, 25, pageId));
            }
            return View(_costDefine.GetAll(25,pageId));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costDefine = await _costDefine.GetById(id.Value);
            if (costDefine == null)
            {
                return NotFound();
            }

            return View(costDefine);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CostDefineId,Name,Description,InsertDate,IsDelete,UpDateTime")] CostDefine costDefine)
        {
            if (ModelState.IsValid)
            {

                costDefine.InsertDate = DateTime.Now;
                costDefine.UpDateTime=DateTime.Now;
                _costDefine.Add(costDefine);

                return RedirectToAction(nameof(Index), "CostDefine", new { area = "Admin" });
            }
            return View(costDefine);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costDefine = await _costDefine.GetById(id.Value);
            if (costDefine == null)
            {
                return NotFound();
            }
            return View(costDefine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CostDefineId,Name,Description,InsertDate,IsDelete,UpDateTime")] CostDefine costDefine)
        {
            if (id != costDefine.CostDefineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    costDefine.UpDateTime = DateTime.Now;
                    _costDefine.Update(costDefine);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostDefineExists(costDefine.CostDefineId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "CostDefine", new { area = "Admin" });
            }
            return View(costDefine);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costDefine = await _costDefine.GetById(id.Value);

            if (costDefine == null)
            {
                return NotFound();
            }

            return View(costDefine);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costDefine = await _costDefine.GetById(id);
            _costDefine.Delete(costDefine);

            return RedirectToAction(nameof(Index), "CostDefine", new { area = "Admin" });
        }

        private bool CostDefineExists(int id)
        {
            return _costDefine.Exist(id);
        }
    }
}
