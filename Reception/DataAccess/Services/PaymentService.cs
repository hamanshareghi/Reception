using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Library;
using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DataAccess.Services
{
    public class PaymentService : IPayment
    {
        private DataContext _context;

        public PaymentService(DataContext context)
        {
            _context = context;
        }
        public List<Payment> GetAll()
        {
            return _context.Payments
                .Include(s => s.User)
                .OrderByDescending(s=>s.PaymentDate)
                .ToList();
        }

        public Tuple<List<Payment>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Payments
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
            var query = _context.Payments
                .Include(s => s.User)
                .OrderByDescending(s => s.PaymentDate)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public Tuple<List<Payment>, int> GetPaymentBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Payments
                .Count(
                    s => s.User.FullName.ToLower().Contains(search)
                    || s.Description.ToLower().Contains(search)
                    || s.Price.ToString().ToLower().Contains(search)
                    || s.PaymentDate.ToShamsi().ToLower().Contains(search)
                    || s.Destination.ToLower().Contains(search)
                    || s.Source.ToLower().Contains(search)
                    || s.Recipt.ToLower().Contains(search)
                    || s.User.PhoneNumber.Contains(search)
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
            var query = _context.Payments
                .Include(s => s.User)
                .Where(
                    s => s.User.FullName.ToLower().Contains(search)
                         || s.Description.ToLower().Contains(search)
                         || s.Price.ToString().ToLower().Contains(search)
                         || s.PaymentDate.ToShamsi().ToLower().Contains(search)
                         || s.Destination.ToLower().Contains(search)
                         || s.Source.ToLower().Contains(search)
                         || s.Recipt.ToLower().Contains(search)
                         || s.User.PhoneNumber.Contains(search)
                )
                .OrderByDescending(s => s.PaymentDate)

                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public Payment GetById(int id)
        {
            return _context.Payments
                .Include(s => s.User)
                .FirstOrDefault(s => s.PaymentId == id);
        }

        public void Add(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public void Update(Payment payment)
        {
            _context.Payments.Update(payment);
            _context.SaveChanges();
        }

        public void Delete(Payment payment)
        {
            payment.IsDelete = true;
            Update(payment);
        }

        public bool Exist(int id)
        {
            return _context.Payments.Any(s => s.PaymentId == id);
        }

        public int SumPay()
        {
            return _context.Payments.Sum(s => s.Price);
        }

        public List<Payment> GetPaymentFromToDate(string id, string strDate, string endDate)
        {
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now.AddDays(1);

            if (!string.IsNullOrEmpty(strDate))
            {
                string[] std = strDate.Split("/");
                fromDate = new DateTime(int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new PersianCalendar()
                );
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                string[] std1 = endDate.Split("/");
                toDate = new DateTime(
                    int.Parse(std1[0]),
                    int.Parse(std1[1]),
                    int.Parse(std1[2]),
                    new PersianCalendar()
                );
            }

            IQueryable<Payment> query = _context.Payments
                .Include(s => s.User);

            query = query.Where(
                s => s.User.Id == id);
                

            if (fromDate != null && toDate != null)
            {
                query = query.Where(s => s.PaymentDate >= fromDate && s.PaymentDate <= toDate);

            }
            return query.ToList();
        }
    }
}
