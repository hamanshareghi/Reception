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

        public ReportController(IDebtor debtor)
        {
            _debtor = debtor;
        }
 
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
