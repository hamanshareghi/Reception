using System;
using System.Collections.Generic;
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
    }
}
