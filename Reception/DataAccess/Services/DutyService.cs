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
    public class DutyService : IDuty

    {
        private DataContext _context;

        public DutyService(DataContext context)
        {
            _context = context;
        }         
        public List<Duty> GetAll()
        {
            return _context.Duties
                .Include(d => d.Reception)
                .ThenInclude(s=>s.Customer)
                .Include(d => d.Service)
                .Include(d => d.Shipping)
                .Include(d => d.Status)
                .OrderByDescending(s => s.UpDateTime)
                .ToList();
        }

        public Duty GetById(int id)
        {
            return _context.Duties
                .Include(d => d.Reception)
                .ThenInclude(s => s.Customer)
                .Include(d => d.Service)
                .Include(d => d.Shipping)
                .Include(d => d.Status)
                .OrderByDescending(s => s.UpDateTime)
                .FirstOrDefault(s => s.DutyId == id);
        }

        public void Add(Duty duty)
        {
            _context.Duties.Add(duty);
            _context.SaveChanges();
        }

        public void Update(Duty duty)
        {
            _context.Duties.Update(duty);
            _context.SaveChanges();
        }

        public void Delete(Duty duty)
        {
            duty.IsDelete = true;
            Update(duty);
        }

        public bool Exist(int id)
        {
            return _context.Duties.Any(s => s.DutyId == id);
        }

        public Tuple<List<Duty>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Duties.Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.Duties
                .Include(d => d.Reception)
                .ThenInclude(s => s.Customer)
                .Include(d => d.Service)
                .Include(d => d.Shipping)
                .Include(d => d.Status)
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public Tuple<List<Duty>, int> GetDutyBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Duties.Count(
                s=>s.Description.ToLower().Contains(search)
                || s.ActionDate.ToShamsi().ToString().Contains(search)
                || s.Price.ToString().ToLower().Contains(search)
                || s.Shipping.Name.ToLower().Contains(search)
                
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

            var query = _context.Duties
                .Include(d => d.Reception)
                .ThenInclude(s => s.Customer)
                .Include(d => d.Service)
                .Include(d => d.Shipping)
                .Include(d => d.Status)
                .Where(
                    s => s.Description.ToLower().Contains(search)
                         || s.ActionDate.ToShamsi().ToString().Contains(search)
                         || s.Price.ToString().ToLower().Contains(search)
                         || s.Shipping.Name.ToLower().Contains(search))
                             .OrderByDescending(s => s.UpDateTime)
                             .Skip(skip)
                             .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public List<Duty> GetDutiesByReception(int id)
        {
            return _context.Duties
                .Include(s => s.Service)
                .Include(s=>s.Shipping)
                .Include(s=>s.Status)
                .Where(s => s.ReceptionId == id)
                .OrderBy(s => s.ActionDate)
                .ToList();
        }
    }
}
