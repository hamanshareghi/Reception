using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RulesController : Controller
    {
        private IRule _rule;

        public RulesController(IRule rule)
        {
            _rule = rule;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _rule.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rule = await _rule.GetById(id.Value);
            if (rule == null)
            {
                return NotFound();
            }

            return View(rule);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sale,Send,Use,Payment,Privacy,Id,InsertDate,IsDelete,UpDateTime")] Rule rule)
        {
            if (ModelState.IsValid)
            {
                rule.InsertDate = DateTime.Now;
                rule.UpDateTime=DateTime.Now;
                _rule.Add(rule);

                return RedirectToAction(nameof(Index), "Rules");
            }
            return View(rule);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rule = await _rule.GetById(id.Value);
            if (rule == null)
            {
                return NotFound();
            }
            return View(rule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sale,Send,Use,Payment,Privacy,Id,InsertDate,IsDelete,UpDateTime")] Rule rule)
        {
            if (id != rule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    rule.UpDateTime = DateTime.Now;
                    _rule.Update(rule);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RuleExists(rule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Rules");
            }
            return View(rule);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rule = await _rule.GetById(id.Value);

            if (rule == null)
            {
                return NotFound();
            }

            return View(rule);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rule = await _rule.GetById(id);
            _rule.Delete(rule);

            return RedirectToAction(nameof(Index), "Rules");
        }

        private bool RuleExists(int id)
        {
            return _rule.Exist(id);
        }
    }
}
