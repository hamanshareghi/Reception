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

        public Task<List<Defect>> GetAll()
        {
            return _context.Defects.ToListAsync();
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
