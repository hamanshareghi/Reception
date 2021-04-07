using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("/Welcome")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
