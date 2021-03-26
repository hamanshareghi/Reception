using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Interfaces;

using Data.Context;

using Model.Entities;

namespace DataAccess.Services
{
    public class FaqService : IFaq
    {
        private DataContext _context;

        public FaqService(DataContext context)
        {
            _context = context;
        }
        public List<Faq> GetAll()
        {
            return _context.Faqs
                .OrderByDescending(s=>s.InsertDate)
                .ToList();
        }

        public Faq GetById(int id)
        {
            return _context.Faqs
                .OrderByDescending(s => s.InsertDate)
                .FirstOrDefault(s => s.FaqId == id);
        }

        public void Add(Faq faq)
        {
            _context.Faqs.Add(faq);
            Save();
        }

        public void Update(Faq faq)
        {
            _context.Faqs.Update(faq);
            Save(); ;
        }

        public void Delete(Faq faq)
        {
            faq.IsDelete = true;
            Update(faq);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
           return _context.Faqs.Any(s => s.FaqId == id);
        }

        public Faq GetFirst()
        {
            return _context.Faqs
                .OrderByDescending(s=>s.InsertDate)
                .First();
        }

        public List<Faq> GetAllWithOutFirst()
        {
            return _context.Faqs
                .OrderByDescending(s => s.InsertDate)
                .Skip(1)
                .ToList();
        }

        public int GetAllFaqCount()
        {
            return _context.Faqs.Count();
        }
    }
}
