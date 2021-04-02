using System;
using System.Collections.Generic;
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
    public class ReceptionsController : Controller
    {
        private IProduct _product;
        private IDefect _defect;
        private IDeviceDefect _deviceDefect;
        private IReception _reception;
        private UserManager<ApplicationUser> _userManager;

        public ReceptionsController(IProduct product, IDefect defect, IDeviceDefect deviceDefect, IReception reception, UserManager<ApplicationUser> userManager)
        {
            _product = product;
            _defect = defect;
            _deviceDefect = deviceDefect;
            _reception = reception;
            _userManager = userManager;
        }
        // GET: Receptions
        public async Task<IActionResult> Index()
        {

            return View(await _reception.GetAll());
        }

        // GET: Receptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reception =await _reception.GetById(id.Value);
            if (reception == null)
            {
                return NotFound();
            }

            return View(reception);
        }

        // GET: Receptions/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["DefectId"] = new SelectList(await _defect.GetAll(), "DefectId", "Name");

            return View();
        }

        // POST: Receptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceptionId,CustomerId,ProductId,Serial,UserId,ReceptionDate,Description,InsertDate,IsDelete,UpDateTime")] Reception reception,List<int> defectsList)
        {
            if (ModelState.IsValid)
            {
                reception.InsertDate = DateTime.Now;
                reception.UpDateTime =DateTime.Now;
                _reception.Add(reception);
                foreach (var item in defectsList)
                {
                    _deviceDefect.Add(new DeviceDefect()
                    {
                        UpDateTime = DateTime.Now,
                        InsertDate = DateTime.Now,
                        ReceptionId = reception.ReceptionId,
                        IsDelete = false,
                        DefectId = item,
                        
                    });
                                       
                }
                
                return RedirectToAction(nameof(Index),"Receptions");
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["DefectId"] = new SelectList(await _defect.GetAll(), "DefectId", "Name");

            return View(reception);
        }

        // GET: Receptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reception = await _reception.GetById(id.Value);
            if (reception == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["DefectId"] = new SelectList(await _defect.GetAll(), "DefectId", "Name");

            return View(reception);
        }

        // POST: Receptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceptionId,CustomerId,ProductId,Serial,UserId,ReceptionDate,Description,InsertDate,IsDelete,UpDateTime")] Reception reception)
        {
            if (id != reception.ReceptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    reception.UpDateTime=DateTime.Now;
                    _reception.Update(reception);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceptionExists(reception.ReceptionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),"Receptions");
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["DefectId"] = new SelectList(await _defect.GetAll(), "DefectId", "Name");

            return View(reception);
        }

        // GET: Receptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reception = await _reception.GetById(id.Value);
            if (reception == null)
            {
                return NotFound();
            }

            return View(reception);
        }

        // POST: Receptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reception = await _reception.GetById(id);
                _reception.Delete(reception);
            return RedirectToAction(nameof(Index),"Receptions");
        }

        private bool ReceptionExists(int id)
        {
            return _reception.Exist(id);
        }
    }
}
