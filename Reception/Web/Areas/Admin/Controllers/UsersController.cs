using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]

    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private IUserValidator<ApplicationUser> userValidator;
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        private RoleManager<ApplicationRole> roleManager;

        public UsersController(UserManager<ApplicationUser> usrMgr,
                RoleManager<ApplicationRole> roleMgr,
                IUserValidator<ApplicationUser> userValid,
                IPasswordValidator<ApplicationUser> passValid,
                IPasswordHasher<ApplicationUser> passwordHash)
        {
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
            roleManager = roleMgr;
        }

        public async Task<IActionResult> Index()
        { 
           return View(await userManager.Users.ToListAsync());
        }
            

        public ViewResult Create()
        {
            var allRoles = roleManager.Roles.ToList();
            ViewBag.Roles = new SelectList(allRoles, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model, List<string> roles)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.PhoneNumber,
                    PhoneNumber = model.PhoneNumber,
                    Contact = model.PhoneNumber,
                    Email = model.Email,
                    FullName = model.FullName,
                    EmailConfirmed = true,
                    InsertDate = DateTime.Now,
                    UpDateTime = DateTime.Now,
                    
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    if (roles != null && roles.Any())
                    {
                        var rolesResult = await userManager.AddToRolesAsync(user, roles);
                    }
                    return RedirectToAction("Index","Users");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            var allRoles = roleManager.Roles.Select(r => new SelectListItem()
            {
                Text = r.Name,
                Value = r.Name,
                Selected = roles.Contains(r.Name)
            });

            ViewBag.Roles = allRoles;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Users");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", userManager.Users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                #region Roles related codes
                var userRoles = await userManager.GetRolesAsync(user);
                var allRoles = roleManager.Roles.Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Name,
                    Selected = userRoles.Contains(r.Name)
                });
                ViewBag.Roles = allRoles;
                #endregion
                return View(user);
            }
            else
            {
                return RedirectToAction("Index","Users");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(
            string id,
            string email,
            string password,
            string address,
            string zipcode,
            List<string> roles)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPassword = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPassword = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPassword.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPassword);
                    }
                }
                if ((validEmail.Succeeded && validPassword == null)
                    || (validEmail.Succeeded && password != string.Empty && validPassword.Succeeded))
                {

                    IdentityResult result = await userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        #region Roles related codes
                        // 1: Get List of User Roles
                        var userRoles = await userManager.GetRolesAsync(user);
                        // 2: Remove current user roles:
                        await userManager.RemoveFromRolesAsync(user, userRoles);
                        if (roles != null && roles.Any())
                        {
                            // 3: Add new roles for this user:
                            await userManager.AddToRolesAsync(user, roles);
                        }
                        #endregion
                        return RedirectToAction("Index","Users");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            var allRoles = roleManager.Roles.Select(r => new SelectListItem()
            {
                Text = r.Name,
                Value = r.Name,
                Selected = roles != null && roles.Contains(r.Name)
            });
            return View(user);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

    }
}
