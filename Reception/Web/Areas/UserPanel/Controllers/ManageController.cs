using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.ViewModels.Customer;
using Microsoft.AspNetCore.Identity;
using Model.Entities;

namespace Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class ManageController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public ManageController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> ShowInfo()
        {
            var user = await  _userManager.GetUserAsync(User);
            ShowInfoViewModel model = new ShowInfoViewModel()
            {
                Address = user.Address,
                Contact = user.PhoneNumber,
                Description = user.Description,
                Email = user.Email,
                FullName = user.FullName,
                InsertDate = user.InsertDate,
                UpDateTime = user.UpDateTime,
            };
            return View(model);
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

    }
}
