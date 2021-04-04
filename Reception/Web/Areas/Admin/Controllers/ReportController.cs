using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private IDebtor _debtor;
        private ICost _cost;

        public ReportController(IDebtor debtor, ICost cost)
        {
            _debtor = debtor;
            _cost = cost;
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



        public IActionResult Debtors()
        {
            var model = _debtor.GetAll();
            return View(model);
        }
    }
}
