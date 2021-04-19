using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Model.Entities;

namespace Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IAllMessage _allMessage;

        public HomeController(UserManager<ApplicationUser> userManager, IAllMessage allMessage)
        {
            _userManager = userManager;
            _allMessage = allMessage;
        }


        [Route("Profile")]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowMessages(string id,int take,int pageId=1)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _allMessage.GetUserMessage(user.Id, 25, pageId = 1);    
            return View(model);
        }
    }
}
