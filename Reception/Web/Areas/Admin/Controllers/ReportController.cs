using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        [HttpGet]
        public IActionResult Costs(string fromDate)
        {
            if (!string.IsNullOrEmpty(fromDate))
            {
                ViewBag.date = fromDate;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Costs()
        {
            return View();
        }
    }
}
