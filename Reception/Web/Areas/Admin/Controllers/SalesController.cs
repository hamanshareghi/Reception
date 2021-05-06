using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Common.Library;
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
        private IAllMessage _allMessage;
        private IPayType _payType;

        public SalesController(ISale sale, UserManager<ApplicationUser> userManager, IProduct product, IAllMessage allMessage, IPayType payType)
        {
            _sale = sale;
            _userManager = userManager;
            _product = product;
            _allMessage = allMessage;
            _payType = payType;
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
            ViewData["PayTypeId"] = new SelectList(_payType.GetAll(), "PayTypeId", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,UserId,CurrentId,SaleDate,ProductId,Count,SalePrice,PayTypeId,ShortKey,Description")] Sale sale,string date)
        {
            if (ModelState.IsValid)
            {


                    sale.InsertDate = DateTime.Now;
                    sale.UpDateTime = DateTime.Now;
                    sale.CurrentId = _userManager.GetUserId(User);
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

                    int saleId = _sale.Add(sale);
                    Sale model = _sale.GetById(saleId);
                    string receptor = "09121950430";
                    string token = model.User.FullName.Replace(" ", "-");
                    string token2 = model.Product.Name.Replace(" ", "-");
                    string token3 = model.SalePrice.ToString("#,0").Replace(" ", "-") + "تومان";
                    string token10 = model.SaleDate.ToShamsi().Replace(" ", "-");
                    string template = "SaleInfo";
                    SendMessage.Send(receptor, token, token2, token3, token10, null, template);

   
                return RedirectToAction(nameof(Index), "Sales", new { area = "Admin" });
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["PayTypeId"] = new SelectList(_payType.GetAll(), "PayTypeId", "Name");

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
            ViewData["PayTypeId"] = new SelectList(_payType.GetAll(), "PayTypeId", "Name");

            return View(sale);
        }
        // POST: Admin/Carousels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,UserId,CurrentId,SaleDate,ProductId,Count,SalePrice,PayTypeId,ShortKey,Description")] Sale sale,string date)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sale.CurrentId = _userManager.GetUserId(User);
                    sale.Count = 1;
                    sale.ShortKey ??= GenerateShortKey(5);

                    if (date != "")
                    {
                        string[] std = date.Split('/');
                        sale.SaleDate = new DateTime(int.Parse(std[0]),
                            int.Parse(std[1]),
                            int.Parse(std[2]),
                            new PersianCalendar()
                        );
                    }
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
            ViewData["PayTypeId"] = new SelectList(_payType.GetAll(), "PayTypeId", "Name");

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

        public IActionResult Send(int id)
        {
            Sale model = _sale.GetById(id);
            string receptor = model.User.Contact;
            string token = model.User.FullName.Replace(" ", "-");
            string token2 = model.Product.Name.Replace(" ", "-");
            string template = "Sale";
            SendMessage.Send(receptor, token, token2, null, null, null, template);

            AllMessage message = new AllMessage()
            {
                InsertDate = DateTime.Now,
                UpDateTime = DateTime.Now,
                IsDelete = false,
                Kind = SmsKind.Sale,
                SmsDate = DateTime.Now,
                CurrentUserId = _userManager.GetUserId(User),
                SmsStatus = "Sent",
                Description = $"کاربر: {token}  از خرید شما متشکریم شرح : {token2} ",
                UserId = model.UserId
            };
            _allMessage.Add(message);
            return RedirectToAction("Index", "Sales", new { area = "Admin" });
        }



    }
}
