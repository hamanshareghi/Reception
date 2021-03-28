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
    public class DebtorService : IDebtor
    {

        private DataContext _context;

        public DebtorService(DataContext context)
        {
            _context = context;
        }

        public void Add(Debtor debtor)
        {
            _context.Debtors.Add(debtor);
            _context.SaveChanges();
        }

        public void Delete(Debtor debtor)
        {
            debtor.IsDelete = true;
            _context.Debtors.Update(debtor);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Debtors.Any(s => s.DebtorId == id);
        }

        public Task<List<Debtor>> GetAll()
        {
            return _context.Debtors
                .Include(s=>s.User)
                .ToListAsync();
        }

        public Task<Debtor> GetById(int id)
        {
            return _context.Debtors
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.DebtorId == id);
        }

        public void Update(Debtor debtor)
        {
            _context.Debtors.Update(debtor);
            _context.SaveChanges();
        }
    }
}
