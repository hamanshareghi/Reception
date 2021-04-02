using System;
using System.IO;
using System.Threading.Tasks;
using Common.Library;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    //[Authorize(Roles = "SuperAdmin,Admins")]
    [Area("Admin")]
    //[Authorize]
    public class MessagesController : Controller
    {
        private IMessage _message;

        public MessagesController(IMessage message)
        {
            _message = message;
        }

        // GET: Admin/Messages
        public async Task<IActionResult> Index()
        {
            return View(_message.GetAllMessage());
        }

        // GET: Admin/Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _message.GetMessageById(id.Value);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Admin/Messages/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Admin/Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Text,Image,InsertDate,IsDelete,UpDateTime")] Message message, IFormFile imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    message.Image = NameGenerator.GenerateUniqCode().ToString() + Path.GetExtension(imgUp.FileName);
                    string savePath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img/Messages", message.Image
                    );
                    await using var stream = new FileStream(savePath, FileMode.Create);
                    await imgUp.CopyToAsync(stream);
                }
           
                message.InsertDate=DateTime.Now;
                message.UpDateTime=DateTime.Now;

                _message.AddMessage(message);
                return RedirectToAction(nameof(Index),"Messages",new {Areas="Admin"});
            }
            return View(message);
        }

        // GET: Admin/Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _message.GetMessageById(id.Value);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // POST: Admin/Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text,Image,InsertDate,IsDelete,UpDateTime")] Message message, IFormFile imgUp)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imgUp != null)
                    {
                        var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Messages");

                        var saveName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgUp.FileName);

                        //if (!Directory.Exists(savePath))
                        //    Directory.CreateDirectory(savePath);
                        await using (var streamFile = new FileStream(Path.Combine(savePath, saveName), FileMode.Create))
                            await imgUp.CopyToAsync(streamFile);

                        message.Image = saveName;
                    }
                    _message.UpdateMessage(message);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),"Messages",new {area="Admin"});
            }
            return View(message);
        }

        // GET: Admin/Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _message.GetMessageById(id.Value);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Admin/Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var message = _message.GetMessageById(id);
            _message.DeleteMessage(message);
            return RedirectToAction(nameof(Index),"Messages",new {area="Admin"});
        }

        private bool MessageExists(int id)
        {
            return _message.ExistMessage(id);
        }
    }
}
