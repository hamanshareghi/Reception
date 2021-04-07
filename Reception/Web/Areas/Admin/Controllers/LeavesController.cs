using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admins,SuperAdmin")]
    [Area("Admin")]
    public class LeavesController : Controller
    {
        private ILeave _leave;
        private UserManager<ApplicationUser> _userManager;

        public LeavesController(ILeave leave, UserManager<ApplicationUser> userManager)
        {
            _leave = leave;
            _userManager = userManager;
        }

        // GET: Leaves
        public async Task<IActionResult> Index()
        {
            return View(await _leave.GetAll());
        }

        // GET: Leaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave =await _leave.GetById(id.Value);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // GET: Leaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,StartDate,EndDate,Description,Id,InsertDate,IsDelete,UpDateTime,Confirmation")] Leave leave)
        {
            if (ModelState.IsValid)
            {
                leave.InsertDate=DateTime.Now;
                leave.UpDateTime=DateTime.Now;
                leave.Confirmation = false;
                leave.UserId = _userManager.GetUserId(User);

                _leave.Add(leave);
                return RedirectToAction(nameof(Index),"Leaves");
            }
            return View(leave);
        }

        // GET: Leaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _leave.GetById(id.Value);
            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,StartDate,EndDate,Description,Id,InsertDate,IsDelete,UpDateTime,Confirmation")] Leave leave)
        {
            if (id != leave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    leave.UserId = _userManager.GetUserId(User);
                    leave.UpDateTime=DateTime.Now;
                    _leave.Update(leave);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveExists(leave.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),"Leaves");
            }
            return View(leave);
        }

        // GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leave = await _leave.GetById(id.Value);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leave = await _leave.GetById(id);
            _leave.Delete(leave);
            return RedirectToAction(nameof(Index),"Leaves");
        }

        private bool LeaveExists(int id)
        {
            return _leave.Exist(id);
        }
    }
}
