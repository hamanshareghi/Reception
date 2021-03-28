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

        public Task<List<Shipping>> GetAll()
        {
            return _context.Shippings.ToListAsync();
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
