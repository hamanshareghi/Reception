using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class ReportController : Controller
    {
        private IDebtor _debtor;
        private ICost _cost;
        private ISale _sale;

        public ReportController(IDebtor debtor, ICost cost, ISale sale)
        {
            _debtor = debtor;
            _cost = cost;
            _sale = sale;
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
    }
}
