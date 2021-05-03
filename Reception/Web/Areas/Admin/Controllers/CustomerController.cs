﻿using System;
using System.Threading.Tasks;
using Common.Library;
using Data.ViewModels.Customer;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admins,SuperAdmin")]
    [Area("Admin")]
    public class CustomerController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private ICustomer _customer;
        private RoleManager<ApplicationRole> _roleManager;
        private IAllMessage _allMessage;

        public CustomerController(UserManager<ApplicationUser> userManager, ICustomer customer, RoleManager<ApplicationRole> roleManager, IAllMessage allMessage)
        {
            _userManager = userManager;
            _customer = customer;
            _roleManager = roleManager;
            _allMessage = allMessage;
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    UserKind = UserKind.Customer,
                    Email = model.Email,
                    FullName = model.FullName,
                    EmailConfirmed = true,
                    Position = "Customer",
                    IsDelete = false,
                    InsertDate = DateTime.Now,
                    UpDateTime = DateTime.Now,
                    
                };
                IdentityResult result = await _userManager.CreateAsync(customer, "Password@1");
                if (result.Succeeded)
                {
                    
                    var rolesResult = await _userManager.AddToRoleAsync(customer, "Users");

                    var currentUser = await _customer.GetById(customer.Id);
                    string receptor = currentUser.PhoneNumber;
                    //var name = _userManager.FindByIdAsync(model.UserId);

                    string token = currentUser.FullName.Replace(" ", "-");
                    string token2 = currentUser.PhoneNumber;
                    string token3 = "Password@1";

                    SendMessage.Send(receptor, token, token2, token3, null, null, "CustomerInfo");
                    AllMessage message = new AllMessage()
                    {
                        InsertDate = DateTime.Now,
                        UpDateTime = DateTime.Now,
                        IsDelete = false,
                        Kind = SmsKind.Customer,
                        SmsDate = DateTime.Now,
                        CurrentUserId = _userManager.GetUserId(User),
                        SmsStatus = "Sent",
                        Description = $"کاربر: {token} نام کاربری: {token2} رمزعبور: {token3} ",
                        UserId = currentUser.Id
                    };
                    _allMessage.Add(message);

                    return RedirectToAction("Index","Customer",new {area="Admin"});
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

        public IActionResult Index(string search,int pageId = 1)
        {
            
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View( _customer.GetUserBySearch(search,pageId));
            }
            
            return View (  _customer.GetAll(pageId));
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
                Email = model.Email,
               
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                result.UpDateTime=DateTime.Now;
                
                var editResult =await _userManager.UpdateAsync(result);
                //string message = $"کاربر {model.FullName} خوش آمدید نام کاربری {model.Contact} و رمز عبور : Password@1 برای پیگیری به سایت www.storebit.ir مراجعه کنید";
                //SendMessage.SendSMS(result.PhoneNumber, message);
                if (editResult.Succeeded)
                {
                    return RedirectToAction("Index", "Customer",new {area="Admin"});
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
               result.IsDelete = false;
               result.UpDateTime=DateTime.Now;
               var deleteResult = await _userManager.UpdateAsync(result);
                if (deleteResult.Succeeded)
                {
                    return RedirectToAction("Index", "Customer",new {area="Admin"});
                }

            }
            return View();
        }

        public async Task<IActionResult> Send(string id)
        {
            var model = await _customer.GetById(id);
            string receptor = model.PhoneNumber;
            //var name = _userManager.FindByIdAsync(model.UserId);

            string token = model.FullName.Replace(" ", "-");
            string token2 = model.PhoneNumber;
            string token3 = "Password@1";
            
            SendMessage.Send(receptor, token, token2, token3, null, null, "CustomerInfo");
            AllMessage message = new AllMessage()
            {
                InsertDate = DateTime.Now,
                UpDateTime = DateTime.Now,
                IsDelete = false,
                Kind = SmsKind.Customer,
                SmsDate = DateTime.Now,
                CurrentUserId = _userManager.GetUserId(User),
                SmsStatus = "Sent",
                Description = $"کاربر: {token} نام کاربری: {token2} رمزعبور: {token3} ",
                UserId = model.Id
            };
            _allMessage.Add(message);
            return RedirectToAction("Index", "Customer", new { area = "Admin" });
        }

    }
}
