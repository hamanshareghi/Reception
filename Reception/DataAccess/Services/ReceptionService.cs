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
    public class ReceptionService : IReception
    {
        private DataContext _context;

        public ReceptionService(DataContext context)
        {
            _context = context;
        }
        public Task<List<Reception>> GetAll()
        {
            return _context.Receptions
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .Include(s=>s.Actions)
                .Include(s=>s.DeviceDefects)
                .Include(s=>s.DeviceImages)
                .ToListAsync();
        }

        public Task<Reception> GetById(int id)
        {
            return _context.Receptions
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .Include(s => s.Actions)
                .Include(s => s.DeviceDefects)
                .Include(s => s.DeviceImages)
                .FirstOrDefaultAsync(s=>s.ReceptionId == id);
        }

        public void Add(Reception reception)
        {
            _context.Receptions.Add(reception);
            _context.SaveChanges();
        }

        public void Update(Reception reception)
        {
            _context.Receptions.Update(reception);
            _context.SaveChanges();
        }

        public void Delete(Reception reception)
        {
            reception.IsDelete = true;
            Update(reception);
        }

        public bool Exist(int id)
        {
            return _context.Receptions.Any(s => s.ReceptionId == id);
        }
    }
}
