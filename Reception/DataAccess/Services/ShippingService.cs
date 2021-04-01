using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class ShippingService : IShipping
    {

        private DataContext _context;

        public ShippingService(DataContext context)
        {
            _context = context;
        }

        public void Add(Shipping shipping)
        {
            _context.Shippings.Add(shipping);
            _context.SaveChanges();
        }

        public void Delete(Shipping shipping)
        {
            shipping.IsDelete = true;
            _context.Shippings.Update(shipping);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Shippings.Any(s => s.ShippingId == id);
        }

        public Tuple<List<Shipping>, int> GetShippingBySearch(string search, int pageId)
        {
            int take = 0;
            if (take == 0)
            {
                take = 1;
            }

            int skip = (pageId - 1) * take;

            int pageCount = _context.Shippings
                .Count(s =>
                        s.Contact.ToLower().Contains(search)
                        || s.Description.ToLower().Contains(search)
                        || s.Name.ToLower().Contains(search)
                        || s.Driver.ToLower().Contains(search)
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

            var query = _context.Shippings

                    .Where(s =>
                        s.Contact.ToLower().Contains(search)
                        || s.Description.ToLower().Contains(search)
                        || s.Name.ToLower().Contains(search)
                        || s.Driver.ToLower().Contains(search)
                    )
                    .OrderByDescending(s => s.UpDateTime)
                    .Skip(skip)
                    .Take(take)
                    .ToList();
            return Tuple.Create(query, pageCount);
        }

        public Tuple<List<Shipping>, int> GetAll(int pageId = 1)
        {
            int take = 0;
            if (take == 0)
            {
                take = 1;
            }

            int skip = (pageId - 1) * take;

            int pageCount = _context.Shippings.Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.Shippings
                .Skip(skip)
                .Take(take)
                .ToList();
            return Tuple.Create(query, pageCount);
        }

        public Task<Shipping> GetById(int id)
        {
            return _context.Shippings.FirstOrDefaultAsync(s => s.ShippingId == id);
        }

        public void Update(Shipping shipping)
        {
            _context.Shippings.Update(shipping);
            _context.SaveChanges();
        }
    }
}
