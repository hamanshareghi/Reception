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
using Common.Library;

namespace DataAccess.Services
{
    public class CostService : ICost
    {

        private DataContext _context;

        public CostService(DataContext context)
        {
            _context = context;
        }

        public void Add(Cost cost)
        {
            _context.Costs.Add(cost);
            _context.SaveChanges();
        }

        public void Delete(Cost cost)
        {
            cost.IsDelete = true;
            Update(cost);

        }

        public bool Exist(int id)
        {
            return _context.Costs.Any(s => s.CostId == id);
        }

        public Tuple<List<Cost>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Costs
                .Include(s => s.CostDefine)
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

            var query = _context.Costs
                .Include(s => s.CostDefine)
                .OrderByDescending(s=>s.UpDateTime)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public Tuple<List<Cost>, int> GetCostBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.Costs.Count(
                s => s.Description.ToLower().Contains(search)
                || s.Price.ToString().ToLower().Contains(search)
                || s.CostDefine.Name.ToLower().Contains(search)
                || s.InsertDate.ToShamsi().ToString().ToLower().Contains(search)
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

            var query = _context.Costs
                .Include(s => s.CostDefine)
                .Where(
                    s => s.Description.ToLower().Contains(search)
                         || s.Price.ToString().ToLower().Contains(search)
                         || s.CostDefine.Name.ToLower().Contains(search)
                         || s.InsertDate.ToShamsi().ToString().ToLower().Contains(search)

                    )
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public List<Cost> GetCostFromToDate(string search, string strDate, string endDate)
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

            IQueryable<Cost> query = _context.Costs.Include(s => s.CostDefine);
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s => s.Description.ToLower().Contains(search)
                                         || s.UserId.ToLower().Contains(search)
                                         || s.Price.ToString().ToLower().Contains(search)
                );
            }

            if (fromDate != null && endDate != null)
            {
                query = query.Where(s => s.UpDateTime >= fromDate && s.UpDateTime <= toDate);
            }

            return query.ToList();
        }

        public List<Cost> GetAll()
        {
            return _context.Costs
                .Include(s => s.CostDefine)
                .OrderByDescending(s => s.UpDateTime)
                .ToList();
        }

        public Cost GetById(int id)
        {
            return _context.Costs
                .Include(s => s.CostDefine)
                .FirstOrDefault(s => s.CostId == id);
        }

        public void Update(Cost cost)
        {
            _context.Costs.Update(cost);
            _context.SaveChanges();
        }
    }
}
