using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admins,SuperAdmin")]
    [Area("Admin")]
    public class TicketsController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ITicket _ticket;

        public TicketsController(UserManager<ApplicationUser> userManager, ITicket ticket)
        {
            _userManager = userManager;
            _ticket = ticket;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
           
            return View(await _ticket.GetAll());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticket.GetById(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["Reciver"] = new SelectList(await _userManager.Users.ToListAsync(), "Id", "FullName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,UserId,Reciver,Subject,Description,MessageStatus,InsertDate,IsDelete,UpDateTime")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.InsertDate=DateTime.Now;
                ticket.UpDateTime=DateTime.Now;
                ticket.MessageStatus = MessageStatus.Unread;
                ticket.UserId = _userManager.GetUserId(User);

                _ticket.Add(ticket);
                return RedirectToAction(nameof(Index),"Tickets");
            }
            ViewData["Reciver"] = new SelectList(await _userManager.Users.ToListAsync(), "Id", "FullName");
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticket.GetById(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["Reciver"] = new SelectList(await _userManager.Users.ToListAsync(), "Id", "FullName");
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,UserId,Reciver,Subject,Description,MessageStatus,InsertDate,IsDelete,UpDateTime")] Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ticket.UpDateTime=DateTime.Now;
                    ticket.MessageStatus = MessageStatus.Seen;
                    ticket.UserId = _userManager.GetUserId(User);
                    _ticket.Update(ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),"Tickets");
            }
            ViewData["Reciver"] = new SelectList(await _userManager.Users.ToListAsync(), "Id", "FullName");
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticket.GetById(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _ticket.GetById(id);
            _ticket.Delete(ticket);
            return RedirectToAction(nameof(Index),"Tickets");
        }

        private bool TicketExists(int id)
        {
            return _ticket.Exist(id);
        }
    }
}
