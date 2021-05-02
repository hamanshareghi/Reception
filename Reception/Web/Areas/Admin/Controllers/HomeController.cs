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
        private IRequestDevice _requestDevice;
        private IAllMessage _allMessage;
        private ICost _cost;
        private IPayment _payment;
        private ISale _sale;
        private IDebtor _debtor;


        public HomeController(ICustomer customer, IReception reception, IRequestDevice requestDevice, IAllMessage allMessage, ICost cost, IPayment payment, ISale sale, IDebtor debtor)
        {
            _customer = customer;
            _reception = reception;
            _requestDevice = requestDevice;
            _allMessage = allMessage;
            _cost = cost;
            _payment = payment;
            _sale = sale;
            _debtor = debtor;
        }


        [Route("/Welcome")]
        public IActionResult Index()
        {
            ViewData["CustomerCount"] = _customer.GetCustomerCount();

            ViewData["ReceptionDone"] = _reception.GetReceptionCountFinish();
            ViewData["ReceptionNotYet"] = _reception.GetReceptionCountNotFinish();

            ViewData["Request"] = _requestDevice.RequestCount();

            ViewData["Sms"] = _allMessage.GetAllMessageCount();

            ViewData["SumPay"] = _payment.SumPay();

            ViewData["TodaySaleCount"] = _sale.TodaySaleCount();
            ViewData["SaleCount"] = _sale.SaleCount();

            ViewData["SumSale"] = _sale.SumSale();
            ViewData["TodaySale"] = _sale.TodaySumSale();
            ViewData["SumDebtor"] = _debtor.SumDebtor();

            ViewData["SumCost"] = _cost.SumCost();
            ViewData["TodaySumCost"] = _cost.TodayCost();
            return View();
        }
    }
}
