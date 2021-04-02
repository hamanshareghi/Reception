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
    public class DefectService : IDefect
    {

        private DataContext _context;

        public DefectService(DataContext context)
        {
            _context = context;
        }

        public void Add(Defect defect)
        {
            _context.Defects.Add(defect);
            _context.SaveChanges();
        }

        public void Delete(Defect defect)
        {
            defect.IsDelete = true;
            _context.Defects.Update(defect);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Defects.Any(s => s.DefectId == id);
        }

        public Tuple<List<Defect>, int> GetDefectBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Defects.Count(
                s => s.Description.ToLower().Contains(search)
                || s.Name.ToLower().Contains(search)
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

            var query = _context.Defects
                .Where(s => s.Description.ToLower().Contains(search)
                            || s.Name.ToLower().Contains(search))
                             .Skip(skip)
                             .Take(take)
                             .ToList();
            return Tuple.Create(query, pageCount);
        }

        public List<Defect> GetAll()
        {
            return _context.Defects.ToList();
        }

        public Tuple<List<Defect>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Defects.Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.Defects
                    .Skip(skip)
                    .Take(take)
                    .ToList();
            return Tuple.Create(query, pageCount);
        }

        public Task<Defect> GetById(int id)
        {
            return _context.Defects.FirstOrDefaultAsync(s => s.DefectId == id);
        }

        public void Update(Defect defect)
        {
            _context.Defects.Update(defect);
            _context.SaveChanges();
        }
    }
}
