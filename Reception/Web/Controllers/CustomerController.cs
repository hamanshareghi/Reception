using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.ViewModels.Customer;
using Microsoft.AspNetCore.Identity;
using Model.Entities;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;

        public CustomerController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                bool roleExist = await _roleManager.RoleExistsAsync("Users");
                if (!roleExist)
                {

                    var role = new ApplicationRole
                    {
                        Name = "Users"
                    };
                    await _roleManager.CreateAsync(role);
                }
                ApplicationUser customer = new ApplicationUser()
                {
                    Description = model.Description,
                    Contact = model.Contact,
                    PhoneNumber = model.Contact,
                    UserName = model.Contact,
                    Address = model.Address,
                    CustomerKind = Customer.Customer,
                    Email = model.Email,
                    FullName = model.FullName,
                    EmailConfirmed = true,
                    Position = "Customer",
                    
                };
                IdentityResult result = await _userManager.CreateAsync(customer, "Password@1");
                if (result.Succeeded)
                {

                    var rolesResult = await _userManager.AddToRoleAsync(customer, "Users");
                    return Redirect("~/Customer/Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                //}
                //else
                //{
                //    ModelState.AddModelError("PersonId", "این دانش آموز در مدرسه ثبت نام نشده است");
                //}

            }
            return View();
        }

        public IActionResult Index()
        {
            var model = _userManager.Users.ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditCustomer(string Id)
        {
            var model = await _userManager.FindByIdAsync(Id);
            EditCustomerViewModel result = new EditCustomerViewModel()
            {
                Contact = model.PhoneNumber,
                Description = model.Description,
                FullName = model.FullName,
                Address = model.Address,
                Email = model.Email
            };
            return View(result);
        }

        public async Task<IActionResult> EditCustomer(EditCustomerViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _userManager.FindByIdAsync(model.Id);
                result.Description = model.Description;
                result.Contact = model.Contact;
                result.Address = model.Address;
                result.Position = "Customer";
                result.FullName = model.FullName;
                result.Email = model.Email;
                result.PhoneNumber = model.Contact;

                var editResult =await _userManager.UpdateAsync(result);
                if (editResult.Succeeded)
                {
                    return RedirectToAction("Index", "Customer");
                }
                
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            var model = await _userManager.FindByIdAsync(Id);
            DeleteCustomerViewModel result = new DeleteCustomerViewModel()
            {
                Id = model.Id,
                Contact = model.PhoneNumber,
                Description = model.Description,
                FullName = model.FullName,
                Address = model.Address,
                Email = model.Email
            };
            return View(result);
           
        }

        public async Task<IActionResult> Delete(DeleteCustomerViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _userManager.FindByIdAsync(model.Id);
               var deleteResult = await _userManager.DeleteAsync(result);
                if (deleteResult.Succeeded)
                {
                    return RedirectToAction("Index", "Customer");
                }

            }
            return View();
        }

    }
}
