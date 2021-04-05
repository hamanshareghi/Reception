using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class LearnController : Controller
    {
        public IActionResult Articles()
        {
            return View();
        }
        public IActionResult Videos()
        {
            return View();
        }
        public IActionResult Faqs()
        {
            return View();
        }
    }
}
