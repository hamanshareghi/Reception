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
    public class ReceptionService : IReception
    {
        private DataContext _context;

        public ReceptionService(DataContext context)
        {
            _context = context;
        }
        public List<Reception> GetAll()
        {
            return _context.Receptions
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .Include(s=>s.Duties)
                .Include(s=>s.DeviceDefects)
                .Include(s=>s.DeviceImages)
                .ToList();
        }

        public Task<Reception> GetById(int id)
        {
            return _context.Receptions
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .Include(s => s.Duties)
                .Include(s => s.DeviceDefects)
                .Include(s => s.DeviceImages)
                .FirstOrDefaultAsync(s=>s.ReceptionId == id);
        }

        public Reception Add(Reception reception)
        {
            _context.Receptions.Add(reception);
            _context.SaveChanges();
            return reception;
        }

        public void Update(Reception reception)
        {
            _context.Receptions.Update(reception);
            _context.SaveChanges();
        }

        public void Delete(Reception reception)
        {
            reception.IsDelete = true;
            Update(reception);
        }

        public bool Exist(int id)
        {
            return _context.Receptions.Any(s => s.ReceptionId == id);
        }

        public Tuple<List<Reception>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Receptions
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
            var query = _context.Receptions
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .Include(s => s.Duties)
                .Include(s => s.DeviceDefects)
                .Include(s => s.DeviceImages)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public Tuple<List<Reception>, int> GetReceptionBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Receptions
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .Include(s => s.Duties)
                .Include(s => s.DeviceDefects)
                .Include(s => s.DeviceImages)
                .Count(
                    s => s.Description.ToLower().Contains(search)
                         || s.Customer.FullName.ToLower().Contains(search)
                         || s.ReceptionDate.ToString().ToLower().Contains(search)
                         || s.Product.Name.Contains(search)
                         || s.Product.ProductGroup.GroupName.Contains(search)
                         || s.Serial.ToLower().Contains(search)
                         || s.Customer.PhoneNumber.ToLower().Contains(search)

                );
            if (pageCount % take != 0)
            {
                pageCount = pageCount % take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }
            var query = _context.Receptions
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .Include(s => s.Duties)
                .Include(s => s.DeviceDefects)
                .Include(s => s.DeviceImages)
                .Where(
                    s => s.Description.ToLower().Contains(search)
                         || s.Customer.FullName.ToLower().Contains(search)
                         || s.ReceptionDate.ToString().ToLower().Contains(search)
                         || s.Product.Name.Contains(search)
                         || s.Product.ProductGroup.GroupName.Contains(search)
                         || s.Serial.ToLower().Contains(search)
                         || s.Customer.PhoneNumber.ToLower().Contains(search)

                ).Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }
    }
}
