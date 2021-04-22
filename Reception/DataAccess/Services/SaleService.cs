using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DataAccess.Services
{
    public class SaleService :ISale
    {
        private DataContext _context;

        public SaleService(DataContext context)
        {
            _context = context;
        }

        public Tuple<List<Sale>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Sales.Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.Sales
                .Include(s => s.User)
                .Include(s => s.Product)
                .ThenInclude(s=>s.Brand)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);

        }

        public Tuple<List<Sale>, int> GetSaleBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Sales
                .Include(s => s.User)
                .Include(s => s.Product)
                .ThenInclude(s => s.Brand)
                .Count(
                    s=>
                        s.User.FullName.ToLower().Contains(search)
                        || s.User.PhoneNumber.ToLower().Contains(search)
                        || s.Description.ToLower().Contains(search)
                        || s.Product.Brand.Title.ToLower().Contains(search)
                        || s.ShortKey.ToLower().Contains(search)
                        || s.Product.Name.ToLower().Contains(search)
                        || s.Product.Price.ToString().ToLower().Contains(search)

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

            var query = _context.Sales
                .Include(s => s.User)
                .Include(s => s.Product)
                .ThenInclude(s=>s.Brand)
                . Where(
                    s =>
                        s.User.FullName.ToLower().Contains(search)
                        || s.User.PhoneNumber.ToLower().Contains(search)
                        || s.Description.ToLower().Contains(search)
                        || s.Product.Brand.Title.ToLower().Contains(search)
                        || s.ShortKey.ToLower().Contains(search)
                        || s.Product.Name.ToLower().Contains(search)
                        || s.Product.Price.ToString().ToLower().Contains(search)

                )
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public int Add(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
            return sale.SaleId;
        }

        public void Update(Sale sale)
        {
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }

        public void Delete(Sale sale)
        {
            sale.IsDelete = false;
            Update(sale);
        }

        public bool Exist(int id)
        {
            return _context.Sales.Any(s => s.SaleId == id);
        }

        public Sale GetById(int id)
        {
            return _context.Sales
                .Include(s => s.User)
                .Include(s => s.Product)
                .OrderByDescending(s=>s.SaleDate)
                .FirstOrDefault(s => s.SaleId == id);

        }

        public bool ExitsShortKey(string shortKey)
        {
            return _context.Sales.Any(s => s.ShortKey == shortKey);
        }
    }
}
