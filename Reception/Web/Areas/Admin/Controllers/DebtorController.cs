﻿using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DebtorController : Controller
    {
        private IDebtor _debtor;
        private UserManager<ApplicationUser> _userManager;

        public DebtorController(IDebtor debtor, UserManager<ApplicationUser> userManager)
        {
            _debtor = debtor;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string search,int pageId=1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_debtor.GetDebtorBySearch(search, 20, pageId));
            }
            return View( _debtor.GetAll(20,pageId));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debtor = await _debtor.GetById(id.Value);
            if (debtor == null)
            {
                return NotFound();
            }

            return View(debtor);
        }


        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DebtorId,UserId,Title,Price,Description,PayStatus,InsertDate,IsDelete,UpDateTime")] Debtor debtor)
        {
            if (ModelState.IsValid)
            {
                
                debtor.InsertDate = DateTime.Now;
                debtor.UpDateTime=DateTime.Now;
                debtor.PayStatus = PayStatus.NotPaid;
                _debtor.Add(debtor);

                return RedirectToAction(nameof(Index), "Debtor");
            }
            ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View(debtor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debtor = await _debtor.GetById(id.Value);
            if (debtor == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View(debtor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DebtorId,UserId,Title,Price,Description,PayStatus,InsertDate,IsDelete,UpDateTime")] Debtor debtor)
        {
            if (id != debtor.DebtorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    debtor.UpDateTime = DateTime.Now;
                    _debtor.Update(debtor);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DebtorExists(debtor.DebtorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
                return RedirectToAction(nameof(Index), "Debtor");
            }
            return View(debtor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debtor = await _debtor.GetById(id.Value);

            if (debtor == null)
            {
                return NotFound();
            }

            return View(debtor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var debtor = await _debtor.GetById(id);
            _debtor.Delete(debtor);

            return RedirectToAction(nameof(Index), "Debtor");
        }

        private bool DebtorExists(int id)
        {
            return _debtor.Exist(id);
        }
    }
}