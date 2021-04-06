using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Common.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentsController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        private IPayment _payment;

        public PaymentsController(UserManager<ApplicationUser> userManager, IPayment payment)
        {
            _userManager = userManager;
            _payment = payment;
        }
        // GET: Admin/Payments
        public IActionResult Index(string search,int take,int pageId=1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_payment.GetPaymentBySearch(search, 25, pageId));
            }
            return View(_payment.GetAll(25,pageId));
        }

        // GET: Admin/Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _payment.GetById(id.Value);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Admin/Payments/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View();
        }

        // POST: Admin/Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,CustomerId,PaymentDate,Price,Source,Destination,Recipt,Description,InsertDate,IsDelete,UpDateTime")] Payment payment,string date)
        {
            if (ModelState.IsValid)
            {
                payment.IsDelete = false;
                payment.InsertDate=DateTime.Now;
                payment.UpDateTime=DateTime.Now;
                payment.CurrentId = _userManager.GetUserId(User);

                if (date != "")
                {
                    string[] std = date.Split('/');
                    payment.PaymentDate = new DateTime(int.Parse(std[0]),
                        int.Parse(std[1]),
                        int.Parse(std[2]),
                        new PersianCalendar()
                    );
                }
                _payment.Add(payment);
                return RedirectToAction(nameof(Index),"Payments",new{area="Admin"});
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName", payment.CustomerId);
            return View(payment);
        }

        // GET: Admin/Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _payment.GetById(id.Value);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName", payment.CustomerId);
            return View(payment);
        }

        // POST: Admin/Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,CustomerId,PaymentDate,Price,Source,Destination,Recipt,Description,InsertDate,IsDelete,UpDateTime")] Payment payment,string date)
        {
            if (id != payment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    payment.UpDateTime = DateTime.Now;
                    payment.CurrentId = _userManager.GetUserId(User);
                    if (date != "")
                    {
                        string[] std = date.Split('/');
                        payment.PaymentDate = new DateTime(int.Parse(std[0]),
                            int.Parse(std[1]),
                            int.Parse(std[2]),
                            new PersianCalendar()
                        );
                    }
                    _payment.Update(payment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Payments", new { area = "Admin" });
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName", payment.CustomerId);
            return View(payment);
        }

        // GET: Admin/Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _payment.GetById(id.Value);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Admin/Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = _payment.GetById(id);
            _payment.Delete(payment);
            return RedirectToAction(nameof(Index), "Payments", new { area = "Admin" });
        }

        private bool PaymentExists(int id)
        {
            return _payment.Exist(id);
        }
        public IActionResult Send(int id)
        {
            var model = _payment.GetById(id);
            string receptor = model.User.PhoneNumber;
            string token = model.User.FullName.Replace(" ", "-");
            string token2 = model.Source.Replace(" ","-");
            string token3 = model.Destination.Replace(" ", "-");
            string token10 = model.Price.ToString("#,0")+"-تومان";
            string token20 = model.Recipt.Replace(" ","-");
            SendMessage.Send(receptor, token, token2, token3, token10, token20, "Payment");
            return RedirectToAction("Index", "Payments", new { area = "Admin" });
        }
    }
}
