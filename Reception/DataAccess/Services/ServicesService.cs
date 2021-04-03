using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Services
{
    public class ServicesService : IService
    {

        private DataContext _context;

        public ServicesService(DataContext context)
        {
            _context = context;
        }

        public void Add(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void Delete(Service service)
        {
            service.IsDelete = true;
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Services.Any(s => s.ServiceId == id);
        }

        public Tuple<List<Service>, int> GetServiceBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Services.Count(
                s => s.Name.ToLower().Contains(search)
                || s.Description.ToLower().Contains(search)
                || s.Warranty.ToLower().Contains(search)
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

            var query = _context.Services
                .Where(s =>
                    s.Name.ToLower().Contains(search)
                       || s.Description.ToLower().Contains(search)
                       || s.Warranty.ToLower().Contains(search))
                .Skip(skip)
                .Take(take)
                .ToList();
            return Tuple.Create(query, pageCount);
        }

        public List<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        public Tuple<List<Service>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Services.Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.Services
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public Task<Service> GetById(int id)
        {
            return _context.Services.FirstOrDefaultAsync(s => s.ServiceId == id);
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }
    }
}
