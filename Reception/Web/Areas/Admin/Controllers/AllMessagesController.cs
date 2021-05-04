using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admins,SuperAdmin,User")]
    [Area("Admin")]
    public class AllMessagesController : Controller
    {
        private IAllMessage _allMessage;
        private UserManager<ApplicationUser> _userManager;

        public AllMessagesController(IAllMessage allMessage, UserManager<ApplicationUser> userManager)
        {
            _allMessage = allMessage;
            _userManager = userManager;
        }
        // GET: Admin/AllMessages
        public async Task<IActionResult> Index(string search,int pageId=1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_allMessage.GetMessageBySearch(search, 25, pageId));
            }
            return View(_allMessage.GetAll(25,pageId));
        }

        // GET: Admin/AllMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allMessage = _allMessage.GetById(id.Value);
            if (allMessage == null)
            {
                return NotFound();
            }

            return View(allMessage);
        }

        // GET: Admin/AllMessages/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View();
        }

        // POST: Admin/AllMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SmsId,CurrentUserId,UserId,SmsDate,Kind,Description,SmsStatus,InsertDate,IsDelete,UpDateTime")] AllMessage allMessage)
        {
            if (ModelState.IsValid)
            {
                _allMessage.Add(allMessage);
                
                return RedirectToAction(nameof(Index),"AllMessages",new {area="Admin"});
            }
            ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View(allMessage);
        }

        // GET: Admin/AllMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allMessage = _allMessage.GetById(id.Value);
            if (allMessage == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View(allMessage);
        }

        // POST: Admin/AllMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SmsId,CurrentUserId,UserId,SmsDate,Kind,Description,SmsStatus,InsertDate,IsDelete,UpDateTime")] AllMessage allMessage)
        {
            if (id != allMessage.SmsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _allMessage.Update(allMessage);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllMessageExists(allMessage.SmsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),"AllMessages",new {area="Admin"});
            }
            ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View(allMessage);
        }

        // GET: Admin/AllMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allMessage = _allMessage.GetById(id.Value);
            if (allMessage == null)
            {
                return NotFound();
            }

            return View(allMessage);
        }

        // POST: Admin/AllMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allMessage = _allMessage.GetById(id);
            _allMessage.Delete(allMessage);
            return RedirectToAction(nameof(Index),"PayType",new {area="Admin"});
        }

        private bool AllMessageExists(int id)
        {
            return _allMessage.Exist(id);
        }
    }
}
