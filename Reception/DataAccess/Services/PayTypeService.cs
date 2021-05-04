using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DataAccess.Services
{
    public class PayTypeService : IPayType
    {
        private DataContext _context;

        public PayTypeService(DataContext context)
        {
            _context = context;
        }
        public Tuple<List<PayType>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.PayTypes.Count();

            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.PayTypes
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take);

            return Tuple.Create(query.ToList(), pageCount);
        }

        public Tuple<List<PayType>, int> GetPayTypeBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.PayTypes.Count(
                s => s.Description.Contains(search)
                     || s.Account.ToLower().Contains(search)
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

            var query = _context.PayTypes
                    .Where(
                        s => s.Description.Contains(search)
                             || s.Account.ToLower().Contains(search)
                             || s.Name.ToLower().Contains(search)

                    )
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take);

            return Tuple.Create(query.ToList(), pageCount);
        }

        public List<PayType> GetAll()
        {
            return _context.PayTypes.ToList();
        }

        public void Add(PayType payType)
        {
            _context.PayTypes.Add(payType);
            _context.SaveChanges();
        }

        public void Update(PayType payType)
        {
            _context.PayTypes.Update(payType);
            _context.SaveChanges();
        }

        public void Delete(PayType payType)
        {
            payType.IsDelete = true;
            Update(payType);
        }

        public bool Exist(int id)
        {
            return _context.PayTypes.Any(s => s.PayTypeId == id);
        }

        public PayType GetById(int id)
        {
            return _context.PayTypes.FirstOrDefault(s => s.PayTypeId == id);
        }
    }
}
