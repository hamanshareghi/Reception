using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

using Model.Entities;

namespace DataAccess.Services
{
    public class ProductGroupService : IProductGroup
    {
        private DataContext _context;

        public ProductGroupService(DataContext context)
        {
            _context = context;
        }

        public List<ProductGroup> GetAll()
        {
            return _context.ProductGroups
                .Include(g=>g.Products)

                .ToList();
        }

        public ProductGroup GetById(int id)
        {
            var group = _context
                .ProductGroups

                .FirstOrDefault(g => g.ProductGroupId == id);
            return group;
        }

        public void Add(ProductGroup productGroup)
        {
            _context.ProductGroups.Add(productGroup);
            _context.SaveChanges();
        }

        public void Update(ProductGroup productGroup)
        {
            _context.ProductGroups.Update(productGroup);
            _context.SaveChanges();
        }

        public void Delete(ProductGroup productGroup)
        {
            productGroup.IsDelete = true;
            Update(productGroup);
        }

        public bool Exist(int id)
        {
            return  _context.ProductGroups.Any(g => g.ProductGroupId == id);
        }
    }
}
