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
    public class CostDefineService : ICostDefine
    {

        private DataContext _context;

        public CostDefineService(DataContext context)
        {
            _context = context;
        }

        public void Add(CostDefine costDefine)
        {
            _context.CostDefines.Add(costDefine);
            _context.SaveChanges();
        }

        public void Delete(CostDefine costDefine)
        {
            costDefine.IsDelete = true;
            _context.CostDefines.Update(costDefine);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.CostDefines.Any(s => s.CostDefineId == id);
        }

        public IEnumerable<CostDefine> GetAll()
        {
            return _context.CostDefines.ToList();
        }

        public Task<CostDefine> GetById(int id)
        {
            return _context.CostDefines.FirstOrDefaultAsync(s => s.CostDefineId == id);
        }

        public void Update(CostDefine costDefine)
        {
            _context.CostDefines.Update(costDefine);
            _context.SaveChanges();
        }
    }
}
