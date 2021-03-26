using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Services
{
    public class ServicesService : IService
    {

        private DataContext _context;

        public ServicesService(DataContext context)
        {
            _context = context;
        }

        public void Add(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void Delete(Service service)
        {
            service.IsDelete = true;
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Services.Any(s => s.ServiceId == id);
        }

        public Task<List<Service>> GetAll()
        {
            return _context.Services.ToListAsync();
        }

        public Task<Service> GetById(int id)
        {
            return _context.Services.FirstOrDefaultAsync(s => s.ServiceId == id);
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }
    }
}
