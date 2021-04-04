﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Library;
using DataAccess.Interfaces;
using Kavenegar;
using Kavenegar.Models;
using Kavenegar.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReceptionsController : Controller
    {
        public static KavenegarApi Api;
        private IProduct _product;
        private IDefect _defect;
        private IDeviceDefect _deviceDefect;
        private IReception _reception;
        private UserManager<ApplicationUser> _userManager;

        public ReceptionsController(IProduct product, IDefect defect, IDeviceDefect deviceDefect, IReception reception, UserManager<ApplicationUser> userManager)
        {
            _product = product;
            _defect = defect;
            _deviceDefect = deviceDefect;
            _reception = reception;
            _userManager = userManager;
        }
        // GET: Receptions
        public IActionResult Index( string search,int take,int pageId=1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(_reception.GetReceptionBySearch(search, 20, pageId));
            }
            return View( _reception.GetAll(25,pageId));
        }

        // GET: Receptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reception =await _reception.GetById(id.Value);
            if (reception == null)
            {
                return NotFound();
            }

            return View(reception);
        }

        // GET: Receptions/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["DefectId"] = new SelectList( _defect.GetAll(), "DefectId", "Name");

            return View();
        }

        // POST: Receptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("ReceptionId,CustomerId,ProductId,Serial,UserId,ReceptionDate,Description,InsertDate,IsDelete,UpDateTime")] Reception reception,List<int> defectsList,string date="")
        {
            if (ModelState.IsValid)
            {
                reception.InsertDate = DateTime.Now;
                reception.UpDateTime =DateTime.Now;
                reception.UserId = _userManager.GetUserId(User);
                string phone= reception.
               
                if (date != "")
                {
                    string[] std = date.Split('/');
                    reception.ReceptionDate = new DateTime(int.Parse(std[0]),
                        int.Parse(std[1]),
                        int.Parse(std[2]),
                        new PersianCalendar()
                    );
                }


                Reception newReception= _reception.Add(reception);

                foreach (var item in defectsList)
                {
                    _deviceDefect.Add(new DeviceDefect()
                    {
                        UpDateTime = DateTime.Now,
                        InsertDate = DateTime.Now,
                        ReceptionId = reception.ReceptionId,
                        IsDelete = false,
                        DefectId = item,
                        
                    });
                                       
                }

                #region VerifyLookupAsync
               
                KavenegarApi kavenegar = new KavenegarApi("326C4D6F466E46637061714A747930487875702B3072737671766C7045572F4E4345306456574D713953633D");

                SendResult result = null;
                string receptor = newReception.Customer.Contact;
                string token = newReception.Customer.FullName;
                string token2 = newReception.ReceptionId.ToString();
                string token3 = newReception.ReceptionDate.ToString(CultureInfo.InvariantCulture);
                result =  kavenegar.VerifyLookup(receptor,token ,token2  ,token3 , null, null, "Reception", VerifyLookupType.Sms);
                #endregion


                return RedirectToAction(nameof(Index),"Receptions",new {area="Admin"});
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["DefectId"] = new SelectList(_defect.GetAll(), "DefectId", "Name");

            return View(reception);
        }

        // GET: Receptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reception = await _reception.GetById(id.Value);
            if (reception == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["DefectId"] = new SelectList( _defect.GetAll(), "DefectId", "Name");

            return View(reception);
        }

        // POST: Receptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceptionId,CustomerId,ProductId,Serial,UserId,ReceptionDate,Description,InsertDate,IsDelete,UpDateTime")] Reception reception,string date="")
        {
            if (id != reception.ReceptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    reception.UpDateTime=DateTime.Now;
                    reception.UserId = _userManager.GetUserId(User);

                    if (date != "")
                    {
                        string[] std = date.Split('/');
                        reception.ReceptionDate = new DateTime(int.Parse(std[0]),
                            int.Parse(std[1]),
                            int.Parse(std[2]),
                            new PersianCalendar()
                        );
                    }
                    _reception.Update(reception);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceptionExists(reception.ReceptionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),"Receptions");
            }
            ViewData["CustomerId"] = new SelectList(_userManager.Users.ToList(), "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_product.GetAll(), "ProductId", "Name");
            ViewData["DefectId"] = new SelectList( _defect.GetAll(), "DefectId", "Name");

            return View(reception);
        }

        // GET: Receptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reception = await _reception.GetById(id.Value);
            if (reception == null)
            {
                return NotFound();
            }

            return View(reception);
        }

        // POST: Receptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reception = await _reception.GetById(id);
                _reception.Delete(reception);
            return RedirectToAction(nameof(Index),"Receptions");
        }

        private bool ReceptionExists(int id)
        {
            return _reception.Exist(id);
        }
    }
}
