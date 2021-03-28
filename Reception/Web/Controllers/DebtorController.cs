using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    //[Area("Admin")]
    public class DebtorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
