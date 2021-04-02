using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CostController : Controller
    {
        private ICost _cost;
        private ICostDefine _costDefine;

        public CostController(ICost cost, ICostDefine costDefine)
        {
            _cost = cost;
            _costDefine = costDefine;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _cost.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost = await _cost.GetById(id.Value);
            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }


        public IActionResult Create()
        {
            ViewData["CostDefineId"] = new SelectList(_costDefine.GetAll(), "CostDefineId", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CostId,CostDefineId,Price,UserId,Description,InsertDate,IsDelete,UpDateTime")] Cost cost)
        {
            if (ModelState.IsValid)
            {
               
                cost.InsertDate = DateTime.Now;
                cost.UpDateTime=DateTime.Now;
                _cost.Add(cost);

                return RedirectToAction(nameof(Index), "Cost");
            }
            ViewData["CostDefineId"] = new SelectList(_costDefine.GetAll(), "CostDefineId", "Name");
            return View(cost);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost = await _cost.GetById(id.Value);
            if (cost == null)
            {
                return NotFound();
            }
            ViewData["CostDefineId"] = new SelectList(_costDefine.GetAll(), "CostDefineId", "Name");
            return View(cost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CostId,CostDefineId,Price,UserId,Description,InsertDate,IsDelete,UpDateTime")] Cost cost)
        {
            if (id != cost.CostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    cost.UpDateTime = DateTime.Now;
                    _cost.Update(cost);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostExists(cost.CostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["CostDefineId"] = new SelectList(_costDefine.GetAll(), "CostDefineId", "Name");
                return RedirectToAction(nameof(Index), "Cost");
            }
            return View(cost);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost = await _cost.GetById(id.Value);

            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cost = await _cost.GetById(id);
            _cost.Delete(cost);

            return RedirectToAction(nameof(Index), "Cost");
        }

        private bool CostExists(int id)
        {
            return _cost.Exist(id);
        }
    }
}
