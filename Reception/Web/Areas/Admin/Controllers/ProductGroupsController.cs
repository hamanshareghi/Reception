using System;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductGroupsController : Controller
    {
        private IProductGroup _productGroup;


        public ProductGroupsController(IProductGroup productGroup)
        {
            _productGroup = productGroup;
           
        }

        // GET: Admin/ProductGroups
        public async Task<IActionResult> Index(string search,int take,int pageId=1)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                return View(_productGroup.GetProductGroupBySearch(search, 25, pageId));
            }
            
            return View(_productGroup.GetAll(25,pageId));
        }

        // GET: Admin/ProductGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = _productGroup.GetById(id.Value);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // GET: Admin/ProductGroups/Create
        public IActionResult Create()
        {
            //ViewData["CompanyId"] = new SelectList(_company.GetAll(), "CompanyId", "Title");
            ViewData["ParentId"] = new SelectList(_productGroup.GetAll(), "ProductGroupId", "GroupName");
            return View();
        }

        // POST: Admin/ProductGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductGroupId,ParentId,CompanyId,GroupName,Image,Banner")] ProductGroup productGroup,IFormFile imgUp,IFormFile imgUp2)
        {
            if (ModelState.IsValid)
            {
               productGroup.InsertDate=DateTime.Now;
               productGroup.UpDateTime=DateTime.Now;
                _productGroup.Add(productGroup);

                return RedirectToAction(nameof(Index), "ProductGroups");
            }
            //ViewData["CompanyId"] = new SelectList(_company.GetAll(), "CompanyId", "Title", productGroup.CompanyId);
            ViewData["ParentId"] = new SelectList(_productGroup.GetAll(), "ProductGroupId", "GroupName");
            return View(productGroup);
        }

        // GET: Admin/ProductGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = _productGroup.GetById(id.Value);
            if (productGroup == null)
            {
                return NotFound();
            }
            //ViewData["CompanyId"] = new SelectList(_company.GetAll(), "CompanyId", "Title", productGroup.CompanyId);
            ViewData["ParentId"] = new SelectList(_productGroup.GetAll(), "ProductGroupId", "GroupName");
            return View(productGroup);
        }

        // POST: Admin/ProductGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductGroupId,ParentId,CompanyId,GroupName,Image,Banner")] ProductGroup productGroup,IFormFile imgUp, IFormFile imgUp2)
        {
            if (id != productGroup.ProductGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                   
                    productGroup.UpDateTime=DateTime.Now;
                    _productGroup.Update(productGroup);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductGroupExists(productGroup.ProductGroupId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),"ProductGroups");
            }
            //ViewData["CompanyId"] = new SelectList(_company.GetAll(), "CompanyId", "Title", productGroup.CompanyId);
            ViewData["ParentId"] = new SelectList(_productGroup.GetAll(), "ProductGroupId", "GroupName");
            return View(productGroup);
        }

        // GET: Admin/ProductGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = _productGroup.GetById(id.Value);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // POST: Admin/ProductGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productGroup = _productGroup.GetById(id);
            productGroup.IsDelete = true;
            _productGroup.Delete(productGroup);
            return RedirectToAction(nameof(Index), "ProductGroups");
        }

        private bool ProductGroupExists(int id)
        {
            return _productGroup.Exist(id);
        }
    }
}
