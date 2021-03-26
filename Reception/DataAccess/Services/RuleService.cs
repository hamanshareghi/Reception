using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Model.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class RuleService : IRule
    {
        private DataContext _context;

        public RuleService(DataContext context)
        {
            _context = context;
        }

        public void Add(Rule rule)
        {
            _context.Rules.Add(rule);
            _context.SaveChanges();
        }

        public void Delete(Rule rule)
        {
            rule.IsDelete = true;
            _context.Rules.Update(rule);
   
        }

        public bool Exist(int id)
        {
            return _context.Rules.Any(s => s.Id == id);
        }

        public Task<Rule> GetFirst()
        {
            return  _context.Rules.FirstOrDefaultAsync();
        }

        public Task<List<Rule>> GetAll()
        {
            return _context.Rules.ToListAsync();
        }

        public Task<Rule> GetById(int id)
        {
            return _context.Rules.FirstOrDefaultAsync(s => s.Id == id);
        }

        public void Update(Rule rule)
        {
            _context.Rules.Update(rule);
            _context.SaveChanges();
        }
    }
}
