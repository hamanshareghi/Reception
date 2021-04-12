using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace Web.Areas.Admin.Controllers
{

    [Area("Admin")]


    public class HomeController : Controller
    {
        private ICustomer _customer;
        private IReception _reception;

        public HomeController(ICustomer customer, IReception reception)
        {
            _customer = customer;
            _reception = reception;
        }


        [Route("/Welcome")]
        public IActionResult Index()
        {
            ViewData["CustomerCount"] = _customer.GetCustomerCount();
            ViewData["ReceptionDone"] = _reception.GetReceptionCountFinish();
            ViewData["ReceptionNotYet"] = _reception.GetReceptionCountNotFinish();

            return View();
        }
    }
}
