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
    public class CostService : ICost
    {

        private DataContext _context;

        public CostService(DataContext context)
        {
            _context = context;
        }

        public void Add(Cost cost)
        {
            _context.Costs.Add(cost);
            _context.SaveChanges();
        }

        public void Delete(Cost cost)
        {
            cost.IsDelete = true;
            Update(cost);
          
        }

        public bool Exist(int id)
        {
            return _context.Costs.Any(s => s.CostId == id);
        }

        public Task<List<Cost>> GetAll()
        {
            return _context.Costs
                .Include(s=>s.CostDefine)
                .OrderByDescending(s=>s.UpDateTime)
                .ToListAsync();
        }

        public Task<Cost> GetById(int id)
        {
            return _context.Costs
                .Include(s => s.CostDefine)
                .FirstOrDefaultAsync(s => s.CostId == id);
        }

        public void Update(Cost cost)
        {
            _context.Costs.Update(cost);
            _context.SaveChanges();
        }
    }
}
