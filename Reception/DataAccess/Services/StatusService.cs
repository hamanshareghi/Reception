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
    public class StatusService : IStatus
    {
        DataContext _context;
        public StatusService(DataContext context)
        {
            _context = context;
        }
        public void Add(Status status)
        {
            _context.Status.Add(status);
            _context.SaveChanges();
        }

        public void Delete(Status status)
        {
            status.IsDelete = true;
            _context.Update(status);
        }

        public bool Exist(int id)
        {
            return _context.Status.Any(s => s.StatusId == id);
        }

        public Task<List<Status>> GetAll()
        {
            return _context.Status.ToListAsync();
        }

        public Task<Status> GetById(int id)
        {
            return _context.Status.FirstOrDefaultAsync(s => s.StatusId == id);

        }

        public void Update(Status status)
        {
            _context.Update(status);
            _context.SaveChanges();
        }
    }
}
