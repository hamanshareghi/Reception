using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class ReportController : Controller
    {
        private IDebtor _debtor;
        private ICost _cost;
        private ISale _sale;
        private IPayType _payType;
        private IPayment _payment;
        private UserManager<ApplicationUser> _userManager;

        public ReportController(IDebtor debtor, ICost cost, ISale sale, IPayType payType, IPayment payment, UserManager<ApplicationUser> userManager)
        {
            _debtor = debtor;
            _cost = cost;
            _sale = sale;
            _payType = payType;
            _payment = payment;
            _userManager = userManager;
        }
 
        [HttpGet]
        public IActionResult Costs(string search,string strDate,string endDate)
        {

            return View(_cost.GetCostFromToDate(search,strDate,endDate));
        }

        [HttpPost]
        public IActionResult Costs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Debtors(string search,string strDate,string endDate)
        {
            var model = _debtor.GetDebtorFromToDate(search,strDate,endDate);
            return View(model);
        }
        [HttpPost]
        public IActionResult Debtors()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Sale(string search, string strDate, string endDate)
        {
            var model = _sale.GetSaleFromToDate(search, strDate, endDate);
            return View(model);
        }

        [HttpPost]
        public IActionResult Sale()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PayType(int payTypeId, string strDate, string endDate)
        {
            ViewData["PayTypeId"] = new SelectList(_payType.GetAll(), "PayTypeId", "Name");
            var model = _sale.GetSaleFromToDateByPayType(payTypeId, strDate, endDate);
            return View(model);
        }

        [HttpPost]
        public IActionResult PayType()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Payment(string id, string strDate, string endDate)
        {
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            var model = _payment.GetPaymentFromToDate(id, strDate, endDate);
            return View(model);
        }

        [HttpPost]
        public IActionResult Payment()
        {
            return View();
        }
    }

}
