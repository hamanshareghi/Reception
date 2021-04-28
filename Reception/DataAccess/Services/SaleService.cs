using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DataAccess.Services
{
    public class SaleService : ISale
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
                .ThenInclude(s => s.Brand)
                .OrderByDescending(s => s.UpDateTime)
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
                    s =>
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
                .ThenInclude(s => s.Brand)
                .Where(
                    s =>
                        s.User.FullName.ToLower().Contains(search)
                        || s.User.PhoneNumber.ToLower().Contains(search)
                        || s.Description.ToLower().Contains(search)
                        || s.Product.Brand.Title.ToLower().Contains(search)
                        || s.ShortKey.ToLower().Contains(search)
                        || s.Product.Name.ToLower().Contains(search)
                        || s.Product.Price.ToString().ToLower().Contains(search)

                )
                .OrderByDescending(s => s.UpDateTime)
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
                .OrderByDescending(s => s.SaleDate)
                .FirstOrDefault(s => s.SaleId == id);

        }

        public bool ExitsShortKey(string shortKey)
        {
            return _context.Sales.Any(s => s.ShortKey == shortKey);
        }

        public int SumSale()
        {
            return _context.Sales.Sum(s => s.SalePrice);
        }

        public int SaleCount()
        {
            return _context.Sales.Count();
        }

        public int TodaySumSale()
        {
            DateTime today=DateTime.Now;
            DateTime tomarrow = DateTime.Now.AddDays(1);
            var query =  _context.Sales
                .Where(s => s.SaleDate.Date == today ).ToList();
            int sum = query.Sum(s => s.SalePrice);
            return sum;
        }

        public List<Sale> GetSaleFromToDate(string search, string strDate, string endDate)
        {
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now.AddDays(1);

            if (!string.IsNullOrEmpty(strDate))
            {
                string[] std = strDate.Split("/");
                fromDate = new DateTime(int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new PersianCalendar()
                );
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                string[] std1 = endDate.Split("/");
                toDate = new DateTime(
                    int.Parse(std1[0]),
                    int.Parse(std1[1]),
                    int.Parse(std1[2]),
                    new PersianCalendar()
                );
            }

            IQueryable<Sale> query = _context.Sales
                .Include(s => s.User)
                .Include(s => s.Product)
                .ThenInclude(s => s.ProductGroup)
                .Include(s => s.Product.Brand);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    s => s.User.PhoneNumber.ToLower().Contains(search)
                    || s.User.FullName.ToLower().Contains(search)
                    || s.Product.Brand.Title.ToLower().Contains(search)
                    || s.Product.Name.ToLower().Contains(search)
                    || s.Product.ProductGroup.GroupName.ToLower().Contains(search)
                    || s.Description.ToLower().Contains(search)
                    || s.ShortKey.ToLower().Contains(search)

                    )
                    .OrderByDescending(s => s.SaleDate);
            }

            if (fromDate != null && toDate != null)
            {
                query = query.Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate);

            }
            return query.ToList();
        }
    }
}
