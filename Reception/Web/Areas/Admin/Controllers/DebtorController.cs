using System;
using System.Linq;
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
    public class DebtorController : Controller
    {
        private IDebtor _debtor;
        private UserManager<ApplicationUser> _userManager;
        private IAllMessage _allMessage;

        public DebtorController(IDebtor debtor, UserManager<ApplicationUser> userManager, IAllMessage allMessage)
        {
            _debtor = debtor;
            _userManager = userManager;
            _allMessage = allMessage;
        }

        public IActionResult Index(string search,int pageId=1)
        {
            ViewData["Sum"] = _debtor.SumDebtor();
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_debtor.GetDebtorBySearch(search, 20, pageId));
            }
            return View( _debtor.GetAll(20,pageId));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debtor =  _debtor.GetById(id.Value);
            if (debtor == null)
            {
                return NotFound();
            }

            return View(debtor);
        }


        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DebtorId,UserId,CurrentUser,Title,Price,Description,PayStatus,InsertDate,IsDelete,UpDateTime")] Debtor debtor)
        {
            if (ModelState.IsValid)
            {
                
                debtor.InsertDate = DateTime.Now;
                debtor.UpDateTime=DateTime.Now;
                debtor.PayStatus = PayStatus.NotPaid;
                debtor.CurrentUser = _userManager.GetUserId(User);

                int newDebtor= _debtor.Add(debtor);
                
                return RedirectToAction(nameof(Index), "Debtor", new { area = "Admin" });
            }
            ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View(debtor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debtor =  _debtor.GetById(id.Value);
            if (debtor == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            return View(debtor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DebtorId,UserId,CurrentUser,Title,Price,Description,PayStatus,InsertDate,IsDelete,UpDateTime")] Debtor debtor)
        {
            if (id != debtor.DebtorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    debtor.CurrentUser = _userManager.GetUserId(User);
                    debtor.UpDateTime = DateTime.Now;
                    _debtor.Update(debtor);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DebtorExists(debtor.DebtorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["UserId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
                return RedirectToAction(nameof(Index), "Debtor",new {area="Admin"});
            }
            return View(debtor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debtor =  _debtor.GetById(id.Value);

            if (debtor == null)
            {
                return NotFound();
            }

            return View(debtor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var debtor =  _debtor.GetById(id);
            _debtor.Delete(debtor);

            return RedirectToAction(nameof(Index), "Debtor", new { area = "Admin" });
        }

        private bool DebtorExists(int id)
        {
            return _debtor.Exist(id);
        }

        public IActionResult Send(int id)
        {
            var model = _debtor.GetById(id);
            string receptor = model.User.PhoneNumber;
            string token = model.User.FullName.Replace(" ","-");
            string token2 = model.Price.ToString("#,0") + "تومان";

            SendMessage.Send(receptor, token, token2, null, null, null, "Debtor");

            AllMessage message = new AllMessage()
            {
                InsertDate = DateTime.Now,
                UpDateTime = DateTime.Now,
                IsDelete = false,
                Kind = SmsKind.Debtor,
                SmsDate = DateTime.Now,
                CurrentUserId = _userManager.GetUserId(User),
                SmsStatus = "Sent",
                Description = $"کاربر: {token} مانده حساب: {token2} لطفا جهت تسویه اقدام بفرمایید",
                UserId = model.UserId
            };
            _allMessage.Add(message);

            return RedirectToAction("Index", "Debtor", new { area = "Admin" });
        }
    }
}
