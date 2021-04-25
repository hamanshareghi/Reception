using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Data.Context;
using Model.Entities;


namespace DataAccess.Services
{
    public class BrandService : IBrand
    {
        private DataContext _context;

        public BrandService(DataContext context)
        {
            _context = context;
        }



        public Tuple<List<Brand>,int> GetAll(int take,int pageId=1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Brands.Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.Brands.ToList();
            return Tuple.Create(query, pageCount);
        }



        public Tuple<List<Brand>, int> GetBrandBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Brands.Count(
                s=>s.Title.ToLower().Contains(search)
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

            var query = _context.Brands
                .Where(s => s.Title.ToLower().Contains(search));
            return Tuple.Create(query.ToList(), pageCount);
        }

        public Brand GetById(int id)
        {
            var brand = _context.Brands.FirstOrDefault(b => b.BrandId == id);
            return brand;
        }

        public void Add(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void Delete(Brand brand)
        {
            brand.IsDelete = true;
            Update(brand);
        }

        public void Update(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Brands.Any(b => b.BrandId == id);
        }

        public List<Brand> GetAll()
        {
            return _context.Brands.ToList();
        }
    }
}
