using System;
using System.Threading.Tasks;
using Common.Library;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admins,SuperAdmin")]
    [Area("Admin")]
    public class CostController : Controller
    {
        private ICost _cost;
        private ICostDefine _costDefine;
        private UserManager<ApplicationUser> _userManager;
        private IAllMessage _allMessage;

        public CostController(ICost cost, ICostDefine costDefine, UserManager<ApplicationUser> userManager, IAllMessage allMessage)
        {
            _cost = cost;
            _costDefine = costDefine;
            _userManager = userManager;
            _allMessage = allMessage;
        }

        public  IActionResult Index(string search ,int take,int pageId=1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                return View(_cost.GetCostBySearch(search, 25, pageId));
            }
            return View(_cost.GetAll(25,pageId));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost =  _cost.GetById(id.Value);
            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }


        public IActionResult Create()
        {
            ViewData["CostDefineId"] = new SelectList(_costDefine.GetAll(), "CostDefineId", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CostId,CostDefineId,Price,UserId,Description,InsertDate,IsDelete,UpDateTime")] Cost cost)
        {
            if (ModelState.IsValid)
            {
               
                cost.InsertDate = DateTime.Now;
                cost.UpDateTime=DateTime.Now;
                cost.UserId = _userManager.GetUserId(User);
                int newCost= _cost.Add(cost);
                var model = _cost.GetById(newCost);
                string receptor = "09121950430";
                //var name = _userManager.FindByIdAsync(model.UserId);

                string token = model.User.FullName.Replace(" ","-");
                string token2 = model.Price.ToString("#,0") + "تومان";
                string token3 = model.CostDefine.Name.Replace(" ", "-");
                SendMessage.Send(receptor, token, token2, token3, null, null, "Cost");
                AllMessage message = new AllMessage()
                {
                    InsertDate = DateTime.Now,
                    UpDateTime = DateTime.Now,
                    IsDelete = false,
                    Kind = SmsKind.Cost,
                    SmsDate = DateTime.Now,
                    CurrentUserId = _userManager.GetUserId(User),
                    SmsStatus = "Sent",
                    Description = $"کاربر: {token} مبلغ: {token2} بابت: {token3} ",
                    UserId = model.UserId
                };
                _allMessage.Add(message);

                return RedirectToAction(nameof(Index), "Cost",new {area="Admin"});
            }
            ViewData["CostDefineId"] = new SelectList(_costDefine.GetAll(), "CostDefineId", "Name");
            return View(cost);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost =  _cost.GetById(id.Value);
            if (cost == null)
            {
                return NotFound();
            }
            ViewData["CostDefineId"] = new SelectList(_costDefine.GetAll(), "CostDefineId", "Name");
            return View(cost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CostId,CostDefineId,Price,UserId,Description,InsertDate,IsDelete,UpDateTime")] Cost cost)
        {
            if (id != cost.CostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    cost.UpDateTime = DateTime.Now;
                    cost.UserId = _userManager.GetUserId(User);
                    _cost.Update(cost);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostExists(cost.CostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["CostDefineId"] = new SelectList(_costDefine.GetAll(), "CostDefineId", "Name");
                return RedirectToAction(nameof(Index), "Cost", new { area = "Admin" });
            }
            return View(cost);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost =  _cost.GetById(id.Value);

            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cost =  _cost.GetById(id);
            _cost.Delete(cost);

            return RedirectToAction(nameof(Index), "Cost", new { area = "Admin" });
        }

        private bool CostExists(int id)
        {
            return _cost.Exist(id);
        }

        public  IActionResult Send(int id)
        {
            var model = _cost.GetById(id);
            string receptor = "09121950430";
            //var name = _userManager.FindByIdAsync(model.UserId);

            string token = model.UserId.Substring(0, 5);
            string token2 = model.Price.ToString("#,0")+"تومان" ;
            string token3 = model.CostDefine.Name.Replace(" ", "-");
            SendMessage.Send(receptor, token, token2, token3,null,null, "Cost");
            AllMessage message = new AllMessage()
            {
                InsertDate = DateTime.Now,
                UpDateTime = DateTime.Now,
                IsDelete = false,
                Kind = SmsKind.Cost,
                SmsDate = DateTime.Now,
                CurrentUserId = _userManager.GetUserId(User),
                SmsStatus = "Sent",
                Description = $"کاربر: {token} مبلغ: {token2} بابت: {token3} ",
                UserId = model.UserId
            };
            _allMessage.Add(message);
            return RedirectToAction("Index", "Cost", new {area = "Admin"});
        }
    }
}
