using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;
using Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Model.Entities;

namespace DataAccess.Services
{
    public class ProductService : IProduct
    {
        private DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
 
        public List<Product> GetAll()
        {
           return _context.Products
                   .Include(p => p.ProductGroup)
                   .Include(p=>p.Brand)
                   .ToList();
        }

        public Product GetById(int id)
        {
            var product =  _context.Products
                .Include(p => p.ProductGroup)

                .Include(p => p.Brand)
                .FirstOrDefault(m => m.ProductId == id);
            return product;
        }

        public void Add(Product product,IFormFile imgUp)
        {

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            product.IsDelete = true;
            Update(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }

        public List<Product> GetProducts(string query)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByGroup(int id)
        {
            var listProduct = _context.Products
                .Include(p => p.ProductGroup)
                .Include(p => p.Brand)
                .Where(p => p.ProductGroupId == id)
                .ToList();
            return listProduct;
        }

        public List<Product> GetProductByCount(int count = 0)
        {
            var product = _context.Products
                .Include(p => p.ProductGroup)

                .Include(p => p.Brand)
                .OrderByDescending(p => p.InsertDate)
                .Take(count).ToList();
            return product;
        }

        public void UpdateVisitCount(Product product)
        {
            //product.VisitCount += 1;
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        //public List<Product> GetSpecial(int count)
        //{
        //    var product = _context.Products
        //        .Include(p=>p.ProductGroup)
        //        .Include(p => p.Brand)
        //        .OrderByDescending(p => p.UpDateTime)
        //        .Where(p=>p.InOff)
        //        .Take(count)
        //        .ToList();
        //    return product;

        //}

        public bool ProductExist()
        {
            return _context.Products.Any();
        }



        //public bool ShortKeyExist(string shortKey)
        //{
        //    return _context.Products.Any(s => s.ShortKey == shortKey);
        //}

        //public Product GetByShortKey(string shortKey)
        //{
        //    return _context.Products
        //        .Include(s => s.ProductGroup)
        //        .FirstOrDefault(s => s.ShortKey == shortKey);
        //}

        //public Tuple<Product, Product> GetTwoProductForOffer()
        //{
        //    var First = _context.Products
        //        .Include(s => s.ProductGroup)
        //        .OrderByDescending(s => s.UpDateTime)
        //        .FirstOrDefault(s => s.InOff == true);
        //    var Second = _context.Products
        //        .Include(s => s.ProductGroup)
        //        .OrderByDescending(s => s.UpDateTime)
        //        .Where(s => s.InOff == true)
        //        .Skip(1)
        //        .Single();
        //    return Tuple.Create(First, Second);
        //}

        //public Product GetFirstOffer()
        //{
        //    return _context.Products
        //        .Include(s => s.ProductGroup)
        //        .OrderByDescending(s => s.UpDateTime)
        //        .FirstOrDefault(s => s.InOff == true);
        //}

        //public Product GetSecondOffer()
        //{
        //    return _context.Products
        //        .Include(s => s.ProductGroup)
        //        .OrderByDescending(s => s.UpDateTime)
        //        .Where(s => s.InOff == true)
        //        .Skip(1)
        //        .SingleOrDefault();
        //}
    }
}
