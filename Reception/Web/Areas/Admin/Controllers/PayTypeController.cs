using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles="SuperAdmin")]
    [Area("Admin")]
    public class PayTypeController : Controller
    {
        private IPayType _pay;

        public PayTypeController(IPayType pay)
        {
            _pay = pay;
        }
        public async Task<IActionResult> Index(string search, int pageId = 1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_pay.GetPayTypeBySearch(search, 25, pageId));
            }
            return View(_pay.GetAll(25, pageId));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payType = _pay.GetById(id.Value);
            if (payType == null)
            {
                return NotFound();
            }

            return View(payType);
        }
        // GET: Admin/AllMessages/Create
        public IActionResult Create()
        {
           return View();
        }

        // POST: Admin/AllMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayTypeId,Name,Account,Description,InsertDate,IsDelete,UpDateTime")] PayType payType)
        {
            if (ModelState.IsValid)
            {
                payType.InsertDate=DateTime.Now;
                payType.UpDateTime=DateTime.Now;
                _pay.Add(payType);

                return RedirectToAction(nameof(Index), "PayType", new { area = "Admin" });
            }
            
            return View(payType);
        }
        // GET: Admin/AllMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payType = _pay.GetById(id.Value);
            if (payType == null)
            {
                return NotFound();
            }
            
            return View(payType);
        }

        // POST: Admin/AllMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PayTypeId,Name,Account,Description,InsertDate,IsDelete,UpDateTime")] PayType payType)
        {
            if (id != payType.PayTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    payType.UpDateTime = DateTime.Now;

                    _pay.Update(payType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayTypeExists(payType.PayTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "PayType", new { area = "Admin" });
            }

            return View(payType);
        }
        // GET: Admin/AllMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payType = _pay.GetById(id.Value);
            if (payType == null)
            {
                return NotFound();
            }

            return View(payType);
        }

        // POST: Admin/AllMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payType = _pay.GetById(id);
            _pay.Delete(payType);
            return RedirectToAction(nameof(Index), "PayType", new { area = "Admin" });
        }

        private bool PayTypeExists(int id)
        {
            return _pay.Exist(id);
        }
    }
}
