using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        [Route("Profile")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
