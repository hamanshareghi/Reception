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
    public class LeaveService : ILeave
    {
        private DataContext _context;

        public LeaveService(DataContext context)
        {
            _context = context;
        }
        public Task<List<Leave>> GetAll()
        {
            return _context.Leaves.ToListAsync();
        }

        public Task<Leave> GetById(int id)
        {
            return _context.Leaves.FirstOrDefaultAsync(s => s.Id == id);
        }

        public void Add(Leave leave)
        {
            _context.Leaves.Add(leave);
            _context.SaveChanges();
        }

        public void Update(Leave leave)
        {
            _context.Leaves.Update(leave);
            _context.SaveChanges();
        }

        public void Delete(Leave leave)
        {
            leave.IsDelete = true;
            Update(leave);
        }

        public bool Exist(int id)
        {
            return _context.Leaves.Any(s => s.Id == id);
        }
    }
}
