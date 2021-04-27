using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public int Add(Debtor debtor)
        {
            _context.Debtors.Add(debtor);
            _context.SaveChanges();
            return debtor.DebtorId;
        }

        public void Delete(Debtor debtor)
        {
            debtor.IsDelete = true;
            Update(debtor);
            
        }

        public bool Exist(int id)
        {
            return _context.Debtors.Any(s => s.DebtorId == id);
        }

        public Tuple<List<Debtor>,int> GetDebtorBySearch(string search,int take, int pageId =1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Debtors
                .Include(s => s.User)
                .Count(
                    s=>s.Description.ToLower().Contains(search)
                    || s.User.FullName.ToLower().Contains(search)
                    || s.Title.ToLower().Contains(search)
                    || s.User.PhoneNumber.ToLower().Contains(search)
                    || s.Price.ToString().ToLower().Contains(search)
                    
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
            var query = _context.Debtors
                .Include(s => s.User)
                .Where(
                    s => s.Description.ToLower().Contains(search)
                         || s.User.FullName.ToLower().Contains(search)
                         || s.Title.ToLower().Contains(search)
                         || s.User.PhoneNumber.ToLower().Contains(search)
                         || s.Price.ToString().ToLower().Contains(search)

                );
            return Tuple.Create(query.ToList(), pageCount);

        }

        public List<Debtor> GetDebtorFromToDate(string search, string strDate, string endDate)
        {
            DateTime fromDate = default;
            DateTime toDate = default;
            if (strDate != null)
            {
                string[] std = strDate.Split('/');
                fromDate = new DateTime(int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new PersianCalendar()
                );
            }
            if (endDate != null)
            {
                string[] std1 = endDate.Split('/');
                toDate = new DateTime(int.Parse(std1[0]),
                    int.Parse(std1[1]),
                    int.Parse(std1[2]),
                    new PersianCalendar()
                );
            }
            IQueryable<Debtor> query = _context.Debtors
                .Include(s => s.User)
                .Where(s=>s.PayStatus == PayStatus.NotPaid);
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    s => s.User.FullName.ToLower().Contains(search)
                         || s.User.PhoneNumber.ToLower().Contains(search)
                         || s.Description.ToLower().Contains(search)
                         || s.Title.ToLower().Contains(search)
                );
            }

            if (fromDate != null && toDate != null)
            {
                query = query.Where(s => s.UpDateTime >= fromDate && s.UpDateTime <= toDate);

            }

            return query.ToList();

        }

        public int SumDebtor()
        {
            return _context.Debtors
                .Where(s => s.PayStatus == PayStatus.NotPaid)
                .Sum(s => s.Price);
        }

        public List<Debtor> GetAll()
        {
            return _context.Debtors.ToList();
        }

        public Tuple<List<Debtor>,int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Debtors
                .Include(s => s.User)
                .Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }
            var query = _context.Debtors
                .Include(s => s.User)

                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public Debtor GetById(int id)
        {
            return _context.Debtors
                .Include(s => s.User)
                .FirstOrDefault(s => s.DebtorId == id);
        }

        public void Update(Debtor debtor)
        {
            _context.Debtors.Update(debtor);
            _context.SaveChanges();
        }
    }
}
