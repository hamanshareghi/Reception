﻿using Microsoft.AspNetCore.Mvc;
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
        private IReception _reception;
        private IDuty _duty;
        private IDeviceDefect _deviceDefect;

        public HomeController(UserManager<ApplicationUser> userManager, IAllMessage allMessage, IReception reception, IDuty duty, IDeviceDefect deviceDefect)
        {
            _userManager = userManager;
            _allMessage = allMessage;
            _reception = reception;
            _duty = duty;
            _deviceDefect = deviceDefect;
        }


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

        public async Task<IActionResult> ShowOrder(string id, int take, int pageId = 1)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _reception.GetUserReception(user.Id, 25, pageId = 1);
            return View(model);
        }

        public IActionResult OrderDetail(int id)
        {
            ViewData["Defects"] = _deviceDefect.GetDefectsByReception(id);
            ViewData["Duty"] = _duty.GetDutiesByReception(id);
            var reception = _reception.GetById(id);
            return View(reception);
        }


        public IActionResult FollowOrder(string id,int receptionId)
        {
            //var model = _duty.GetDutiesByReceptionAndUser(id,);
            return View();
        }
    }
}
