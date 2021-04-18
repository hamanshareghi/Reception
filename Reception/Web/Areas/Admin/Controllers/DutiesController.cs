using System;
using System.Globalization;
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
    public class DutiesController : Controller
    {
        private IDuty _duty;
        private IReception _reception;
        private IService _service;
        private IStatus _status;
        private IShipping _shipping;
        private UserManager<ApplicationUser> _userManager;
        private IAllMessage _allMessage;

        public DutiesController(IDuty duty, IReception reception, IService service, IStatus status, IShipping shipping, UserManager<ApplicationUser> userManager, IAllMessage allMessage)
        {
            _duty = duty;
            _reception = reception;
            _service = service;
            _status = status;
            _shipping = shipping;
            _userManager = userManager;
            _allMessage = allMessage;
        }

        // GET: Duties
        public IActionResult Index(string search, int take, int pageId = 1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_duty.GetDutyBySearch(search, 20, pageId));
            }
            return View(_duty.GetAll(25, pageId));
        }

        // GET: Duties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duty =  _duty.GetById(id.Value);
            if (duty == null)
            {
                return NotFound();
            }

            return View(duty);
        }

        // GET: Duties/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ReceptionId"] = new SelectList(_reception.GetAll(), "ReceptionId", "ReceptionId");
            ViewData["ServiceId"] = new SelectList(_service.GetAll(), "ServiceId", "Name");
            ViewData["ShippingId"] = new SelectList(_shipping.GetAll().Item1, "ShippingId", "Name");
            ViewData["StatusId"] = new SelectList(await _status.GetAll(), "StatusId", "Name");
            return View();
        }

        // POST: Duties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DutyId,ReceptionId,ServiceId,ShippingId,Price,ActionDate,Description,StatusId,InsertDate,IsDelete,UpDateTime")] Duty duty, string date)
        {
            if (ModelState.IsValid)
            {
                duty.InsertDate = DateTime.Now;
                duty.UpDateTime = DateTime.Now;
                if (date != "")
                {
                    string[] std = date.Split('/');
                    duty.ActionDate = new DateTime(int.Parse(std[0]),
                        int.Parse(std[1]),
                        int.Parse(std[2]),
                        new PersianCalendar()
                    );
                }


                var newId=_duty.Add(duty);
                Duty newDuty = _duty.GetById(newId);
                string customerId = newDuty.Reception.Customer.Id;
                string receptor = newDuty.Reception.Customer.PhoneNumber;
                string token = newDuty.Reception.Customer.FullName.Replace(" ", "-");
                string token2 = newDuty.ReceptionId.ToString();
                string token3 = newDuty.Service.Name.Replace(" ", "-");
                string token10 = newDuty.Status.Name.Replace(" ", "-");
                SendMessage.Send(receptor, token, token2, token3, token10, null, "Service");
                AllMessage message = new AllMessage()
                {
                    InsertDate = DateTime.Now,
                    UpDateTime = DateTime.Now,
                    IsDelete = false,
                    Kind = SmsKind.Service,
                    SmsDate = DateTime.Now,
                    CurrentUserId = customerId,
                    SmsStatus = "Sent",
                    Description = $"کاربر: {token} -{receptor} پذیرش: {token2} خدمات: {token3} وضعیت: {token10} انجام شد",
                    UserId = _userManager.GetUserId(User)
                };
                _allMessage.Add(message);
                return RedirectToAction(nameof(Index), "Duties", new { area = "Admin" });
            }
            ViewData["ReceptionId"] = new SelectList(_reception.GetAll(), "ReceptionId", "ReceptionId");
            ViewData["ServiceId"] = new SelectList(_service.GetAll(), "ServiceId", "Name");
            ViewData["ShippingId"] = new SelectList(_shipping.GetAll().Item1, "ShippingId", "Name");
            ViewData["StatusId"] = new SelectList(await _status.GetAll(), "StatusId", "Name");
            return View(duty);
        }

        // GET: Duties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duty =  _duty.GetById(id.Value);
            if (duty == null)
            {
                return NotFound();
            }
            ViewData["ReceptionId"] = new SelectList(_reception.GetAll(), "ReceptionId", "ReceptionId");
            ViewData["ServiceId"] = new SelectList(_service.GetAll(), "ServiceId", "Name");
            ViewData["ShippingId"] = new SelectList(_shipping.GetAll().Item1, "ShippingId", "Name");
            ViewData["StatusId"] = new SelectList(await _status.GetAll(), "StatusId", "Name");
            return View(duty);
        }

        // POST: Duties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DutyId,ReceptionId,ServiceId,ShippingId,Price,ActionDate,Description,StatusId,InsertDate,IsDelete,UpDateTime")] Duty duty, string date)
        {
            if (id != duty.DutyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (date != "")
                    {
                        string[] std = date.Split('/');
                        duty.ActionDate = new DateTime(int.Parse(std[0]),
                            int.Parse(std[1]),
                            int.Parse(std[2]),
                            new PersianCalendar()
                        );
                    }
                    duty.UpDateTime = DateTime.Now;
                    _duty.Update(duty);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DutyExists(duty.DutyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Duties", new { area = "Admin" });
            }
            ViewData["ReceptionId"] = new SelectList(_reception.GetAll(), "ReceptionId", "ReceptionId");
            ViewData["ServiceId"] = new SelectList(_service.GetAll(), "ServiceId", "Name");
            ViewData["ShippingId"] = new SelectList(_shipping.GetAll().Item1, "ShippingId", "Name");
            ViewData["StatusId"] = new SelectList(await _status.GetAll(), "StatusId", "Name");
            return View(duty);
        }

        // GET: Duties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duty =  _duty.GetById(id.Value);
            if (duty == null)
            {
                return NotFound();
            }

            return View(duty);
        }

        // POST: Duties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duty =  _duty.GetById(id);
            _duty.Delete(duty);
            return RedirectToAction(nameof(Index), "Duties", new { area = "Admin" });
        }

        private bool DutyExists(int id)
        {
            return _duty.Exist(id);
        }
        public IActionResult Send(int id)
        {
            Duty newDuty = _duty.GetById(id);
            string receptor = newDuty.Reception.Customer.PhoneNumber;
            string token = newDuty.Reception.Customer.FullName.Replace(" ", "-");
            string token2 = newDuty.ReceptionId.ToString();
            string token3 = newDuty.Service.Name.Replace(" ", "-");
            string token10 = newDuty.Status.Name.Replace(" ", "-");
            SendMessage.Send(receptor, token, token2, token3, token10, null, "Service");
            return RedirectToAction("Index", "Duties", new { area = "Admin" });
        }
    }
}
