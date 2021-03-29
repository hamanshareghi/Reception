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
    public class RequestDeviceService : IRequestDevice
    {
        private DataContext _context;

        public RequestDeviceService(DataContext context)
        {
            _context = context;
        }
        public Task<List<RequestDevice>> GetAll()
        {
            return _context.RequestDevices
                .Include(r => r.Product)
                .Include(r => r.User)
                .OrderByDescending(s=>s.UpDateTime)
                .ToListAsync();
        }

        public Task<RequestDevice> GetById(int id)
        {
            return _context.RequestDevices
                .Include(r => r.Product)
                .Include(r => r.User)
                .OrderByDescending(s => s.UpDateTime)
                .FirstOrDefaultAsync(s => s.RequestDeviceId == id);
        }

        public void Add(RequestDevice requestDevice)
        {
            _context.RequestDevices.Add(requestDevice);
            _context.SaveChanges();
        }

        public void Update(RequestDevice requestDevice)
        {
            _context.RequestDevices.Update(requestDevice);
            _context.SaveChanges();
        }

        public void Delete(RequestDevice requestDevice)
        {
           requestDevice.IsDelete=true;
           Update(requestDevice);
        }

        public bool Exist(int id)
        {
            return _context.RequestDevices.Any(s=>s.RequestDeviceId == id);
        }
    }
}
