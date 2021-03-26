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



        public List<Brand> GetAll(int count)
        {
            if (count ==0)
            {
                return _context.Brands.ToList();
            }
            return _context.Brands
                .Take(count)
                .ToList();
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

        
    }
}
