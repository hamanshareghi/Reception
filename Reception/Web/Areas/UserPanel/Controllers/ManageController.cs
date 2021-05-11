using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.ViewModels.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Model.Entities;

namespace Web.Areas.UserPanel.Controllers
{
    //[Authorize(Roles = "Admins,SuperAdmin,User")]
    [Authorize]
    [Area("UserPanel")]
    public class ManageController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public ManageController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Route("/Profile")]
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

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user =await _userManager.GetUserAsync(User);
            EditInfoViewModel model = new EditInfoViewModel()
            {
                FullName = user.FullName,
                Description = user.Description,
                UpDateTime = DateTime.Now,
                Address = user.Address,
                //Contact = user.PhoneNumber,
                CurrentId =user.Id,
                Email = user.Email,
                Contact = user.PhoneNumber
            };
            return View(model);
        }

        public async Task<IActionResult> EditProfile(EditInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                user.Email = model.Email;
                user.Address = model.Address;
                user.EmailConfirmed = true;
                user.IsDelete = false;
                user.UpDateTime = DateTime.Now;
                user.Description = model.Description;
                user.UserName = model.Contact;
                user.Contact = model.Contact;
                    
                
               var result=  await _userManager.UpdateAsync(user);
                if (result == IdentityResult.Success)
                {
                    return RedirectToAction("ShowInfo", "Manage", new { area = "UserPanel" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "خطا در ثبت تغییرات");

                }
            }
            return View(model);
        }

        
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =await _userManager.GetUserAsync(User);
                var result =await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(user);
                }

                await _signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Account/Login");
        }

    }
}
