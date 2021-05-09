using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace Web.Controllers
{
    public class LearnController : Controller
    {
        private IFaq _faq;

        public LearnController(IFaq faq)
        {
            _faq = faq;
        }
        public IActionResult Articles()
        {

            return View();
        }
        public IActionResult Videos()
        {
            return View();
        }
        public IActionResult Faqs(string search,int take , int pageId=1)
        {
            
            var model = _faq.GetAll(25,pageId);
            return View(model);
        }
    }
}
