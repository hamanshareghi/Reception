using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Microsoft.AspNetCore.Authorization;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class AllMessagesController : Controller
    {
        private readonly DataContext _context;

        public AllMessagesController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/AllMessages
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.AllMessages.Include(a => a.Users);
            return View(await dataContext.ToListAsync());
        }

        // GET: Admin/AllMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allMessage = await _context.AllMessages
                .Include(a => a.Users)
                .FirstOrDefaultAsync(m => m.SmsId == id);
            if (allMessage == null)
            {
                return NotFound();
            }

            return View(allMessage);
        }

        // GET: Admin/AllMessages/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
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
                _context.Add(allMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", allMessage.UserId);
            return View(allMessage);
        }

        // GET: Admin/AllMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allMessage = await _context.AllMessages.FindAsync(id);
            if (allMessage == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", allMessage.UserId);
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
                    _context.Update(allMessage);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", allMessage.UserId);
            return View(allMessage);
        }

        // GET: Admin/AllMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allMessage = await _context.AllMessages
                .Include(a => a.Users)
                .FirstOrDefaultAsync(m => m.SmsId == id);
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
            var allMessage = await _context.AllMessages.FindAsync(id);
            _context.AllMessages.Remove(allMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllMessageExists(int id)
        {
            return _context.AllMessages.Any(e => e.SmsId == id);
        }
    }
}
