using System;
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
                .Include(g => g.Products)
                .ToList();
        }

        public Tuple<List<ProductGroup>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.ProductGroups.Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.ProductGroups
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
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
            return _context.ProductGroups.Any(g => g.ProductGroupId == id);
        }

        public Tuple<List<ProductGroup>, int> GetProductGroupBySearch(string search, int take, int pageId)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.ProductGroups.Count(
                s => s.GroupName.ToLower().Contains(search)
                );
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.ProductGroups
                .Where(s => s.GroupName.ToLower().Contains(search))
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take)
                .ToList();
            return Tuple.Create(query, pageCount);
        }
    }
}
