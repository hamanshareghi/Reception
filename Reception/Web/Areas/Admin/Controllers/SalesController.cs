using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")] 
    public class SalesController : Controller
    {
        private ISale _sale;
        private UserManager<ApplicationUser> _userManager;
        private IProduct _product;

        public SalesController(ISale sale, UserManager<ApplicationUser> userManager, IProduct product)
        {
            _sale = sale;
            _userManager = userManager;
            _product = product;
        }
        public IActionResult Index(string search, int pageId = 1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_sale.GetSaleBySearch(search,25, pageId));
            }
            return View(_sale.GetAll(25,pageId));
        }
        // GET: Admin/Carousels/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = _sale.GetById(id.Value);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }
        // GET: Admin/Carousels/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,UserId,CurrentId,SaleDate,ProductId,Count,SalePrice,ShortKey,Description")] Sale sale,string date)
        {
            if (ModelState.IsValid)
            {

                sale.InsertDate = DateTime.Now;
                sale.UpDateTime = DateTime.Now;
                sale.CurrentId =  _userManager.GetUserId(User);
                sale.Count = 1;
                sale.ShortKey = GenerateShortKey(5);

                if (date != "")
                {
                    string[] std = date.Split('/');
                    sale.SaleDate = new DateTime(int.Parse(std[0]),
                        int.Parse(std[1]),
                        int.Parse(std[2]),
                        new PersianCalendar()
                    );
                }

                int saleId= _sale.Add(sale);


                return RedirectToAction(nameof(Index), "Sales", new { area = "Admin" });
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            return View(sale);
        }

        // GET: Admin/Carousels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale =  _sale.GetById(id.Value);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            return View(sale);
        }
        // POST: Admin/Carousels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,UserId,CurrentId,SaleDate,ProductId,Count,SalePrice,ShortKey,Description")] Sale sale,string date)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    sale.UpDateTime = DateTime.Now;
                    _sale.Update(sale);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingExists(sale.SaleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Sales", new { area = "Admin" });
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            return View(sale);
        }

        // GET: Admin/Carousels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = _sale.GetById(id.Value);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Admin/Carousels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = _sale.GetById(id);
            _sale.Delete(sale);
            return RedirectToAction(nameof(Index), "Sales", new { area = "Admin" });
        }

        private bool ShippingExists(int id)
        {
            return _sale.Exist(id);
        }

        private string GenerateShortKey(int length)
        {
            string shortKey = Guid.NewGuid().ToString().Replace("-", "").Substring(0,length);
            if (_sale.ExitsShortKey(shortKey))
            {
                shortKey = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
            }

            return shortKey;
        }

    }
}
