using System;
using System.Collections.Generic;
using System.Linq;
using Data.Context;

using DataAccess.Interfaces;

using Model.Entities;

namespace DataAccess.Services
{
    public class OneDatatService : IOneData
    {
        private DataContext _context;

        public OneDatatService(DataContext context)
        {
            _context = context;
        }


        public List<OneData> GetAll()
        {
          return  _context.OneDatas.ToList();
        }

        public OneData GetById(int id)
        {
            return _context.OneDatas.FirstOrDefault(s => s.Id == id);
        }

        public OneData GetFirst()
        {
            return _context.OneDatas.SingleOrDefault();
        }

        public void Add(OneData oneData)
        {
            _context.OneDatas.Add(oneData);
            _context.SaveChanges();
        }

        public void Delete(OneData oneData)
        {
            _context.OneDatas.Remove(oneData);
            _context.SaveChanges();
        }

        public void Update(OneData oneData)
        {
            _context.OneDatas.Update(oneData);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.OneDatas.Any(s => s.Id == id);
        }
    }
}
