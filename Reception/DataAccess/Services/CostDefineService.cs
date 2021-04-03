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

        public Tuple<List<CostDefine>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.CostDefines.Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.CostDefines
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public Tuple<List<CostDefine>, int> GetCostDefineBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.CostDefines.Count(
                 s=>s.Name.ToLower().Contains(search)
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

            var query = _context.CostDefines
                .Where(
                         s=> s.Name.ToLower().Contains(search)
                    )
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
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
