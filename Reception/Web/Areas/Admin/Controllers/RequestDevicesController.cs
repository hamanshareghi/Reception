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
    public class RequestDevicesController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IProduct _product;
        private IRequestDevice _requestDevice;

        public RequestDevicesController(UserManager<ApplicationUser> userManager, IProduct product, IRequestDevice requestDevice)
        {
            _userManager = userManager;
            _product = product;
            _requestDevice = requestDevice;
        }

        // GET: RequestDevices
        public IActionResult Index(string search, int take, int pageId = 1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_requestDevice.GetRequestDeViceBySearch(search, 20, pageId));
            }
            return View(_requestDevice.GetAll(25, pageId));
        }

        // GET: RequestDevices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestDevice = _requestDevice.GetById(id.Value);
            if (requestDevice == null)
            {
                return NotFound();
            }

            return View(requestDevice);
        }

        // GET: RequestDevices/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["CustomerId"] = new SelectList(await _userManager.Users.ToListAsync(), "Id", "FullName");
            return View();
        }

        // POST: RequestDevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestDeviceId,UserId,CustomerId,ProductId,Description,ViewStatus,InsertDate,IsDelete,UpDateTime")] RequestDevice requestDevice)
        {
            if (ModelState.IsValid)
            {
                requestDevice.InsertDate = DateTime.Now;
                requestDevice.UpDateTime = DateTime.Now;
                requestDevice.ViewStatus = false;
                requestDevice.UserId = _userManager.GetUserId(User);

                _requestDevice.Add(requestDevice);
                return RedirectToAction(nameof(Index), "RequestDevices", new { area = "Admin" });
            }
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["CustomerId"] = new SelectList(await _userManager.Users.ToListAsync(), "Id", "FullName");
            return View(requestDevice);
        }

        // GET: RequestDevices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestDevice = _requestDevice.GetById(id.Value);

            if (requestDevice == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["CustomerId"] = new SelectList(await _userManager.Users.ToListAsync(), "Id", "FullName");
            return View(requestDevice);
        }

        // POST: RequestDevices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestDeviceId,UserId,CustomerId,ProductId,Description,ViewStatus,InsertDate,IsDelete,UpDateTime")] RequestDevice requestDevice)
        {
            if (id != requestDevice.RequestDeviceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    requestDevice.UserId = _userManager.GetUserId(User);
                    requestDevice.UpDateTime = DateTime.Now;
                    requestDevice.ViewStatus = true;
                    _requestDevice.Update(requestDevice);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestDeviceExists(requestDevice.RequestDeviceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "RequestDevices", new { area = "Admin" });
            }
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["CustomerId"] = new SelectList(await _userManager.Users.ToListAsync(), "Id", "FullName");
            return View(requestDevice);
        }

        // GET: RequestDevices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestDevice = _requestDevice.GetById(id.Value);
            if (requestDevice == null)
            {
                return NotFound();
            }

            return View(requestDevice);
        }

        // POST: RequestDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestDevice = _requestDevice.GetById(id);
            _requestDevice.Delete(requestDevice);
            return RedirectToAction(nameof(Index), "RequestDevices", new { area = "Admin" });
        }

        private bool RequestDeviceExists(int id)
        {

            return _requestDevice.Exist(id);
        }

        public IActionResult Send(int id)
        {
            RequestDevice model = _requestDevice.GetById(id);
            string receptor = model.User.Contact;
            string token = model.User.FullName.Replace(" ", "-");
            string token2 = model.Product.Name.Replace(" ", "-");
            string template = "";
            if (model.ViewStatus == false)
            {
                template = "RequestDevice";
            }
            else
            {
                template = "RequestDeviceComplete";
            }
            SendMessage.Send(receptor, token, token2, null, null, null, template);
            return RedirectToAction("Index", "RequestDevices", new { area = "Admin" });
        }
    }
}
