using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Controllers
{
    //[Area("Admin")]
    public class ShippingController : Controller
    {

        private IShipping _shipping;

        public ShippingController(IShipping shipping)
        {
            _shipping = shipping;
        }

        // GET: Admin/Carousels
        public async Task<IActionResult> Index(string search ,int pageId =1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_shipping.GetShippingBySearch(search, pageId));
            }
            return View(  _shipping.GetAll(pageId));
        }

        // GET: Admin/Carousels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping =await _shipping.GetById(id.Value);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // GET: Admin/Carousels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Carousels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Driver,Contact,Description,ShippingId,InsertDate,IsDelete,UpDateTime")] Shipping shipping)
        {
            if (ModelState.IsValid)
            {

                shipping.InsertDate = DateTime.Now;
                _shipping.Add(shipping);

                return RedirectToAction(nameof(Index), "Shipping");
            }
            return View(shipping);
        }

        // GET: Admin/Carousels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = _shipping.GetById(id.Value);
            if (shipping == null)
            {
                return NotFound();
            }
            return View(shipping);
        }

        // POST: Admin/Carousels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name, Driver, Contact, Description, ShippingId, InsertDate, IsDelete, UpDateTime")] Shipping shipping)
        {
            if (id != shipping.ShippingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    shipping.UpDateTime = DateTime.Now;
                    _shipping.Update(shipping);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingExists(shipping.ShippingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Shipping", new { area = "Admin" });
            }
            return View(shipping);
        }

        // GET: Admin/Carousels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = _shipping.GetById(id.Value);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // POST: Admin/Carousels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipping = _shipping.GetById(id);
            return RedirectToAction(nameof(Index), "Shipping", new { area = "Admin" });
        }

        private bool ShippingExists(int id)
        {
            return _shipping.Exist(id);
        }

    }
}
