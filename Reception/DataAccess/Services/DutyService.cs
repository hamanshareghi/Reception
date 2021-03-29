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
    public class DutyService : IDuty

    {
        private DataContext _context;

        public DutyService(DataContext context)
        {
            _context = context;
        }         
        public Task<List<Duty>> GetAll()
        {
            return _context.Duties
                .Include(d => d.Reception)
                .Include(d => d.Service)
                .Include(d => d.Shipping)
                .Include(d => d.Status)
                .OrderByDescending(s => s.UpDateTime)
                .ToListAsync();
        }

        public Task<Duty> GetById(int id)
        {
            return _context.Duties
                .Include(d => d.Reception)
                .Include(d => d.Service)
                .Include(d => d.Shipping)
                .Include(d => d.Status)
                .OrderByDescending(s => s.UpDateTime)
                .FirstOrDefaultAsync(s => s.DutyId == id);
        }

        public void Add(Duty duty)
        {
            _context.Duties.Add(duty);
            _context.SaveChanges();
        }

        public void Update(Duty duty)
        {
            _context.Duties.Update(duty);
            _context.SaveChanges();
        }

        public void Delete(Duty duty)
        {
            duty.IsDelete = true;
            Update(duty);
        }

        public bool Exist(int id)
        {
            return _context.Duties.Any(s => s.DutyId == id);
        }
    }
}
