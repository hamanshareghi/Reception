using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Common.Library;

namespace DataAccess.Services
{
    public class RequestDeviceService : IRequestDevice
    {
        private DataContext _context;

        public RequestDeviceService(DataContext context)
        {
            _context = context;
        }
        public List<RequestDevice> GetAll()
        {
            return _context.RequestDevices
                .Include(r => r.Product)
                .Include(r => r.User)
                .OrderByDescending(s=>s.ViewStatus == false)
                .ThenByDescending(s=>s.UpDateTime)
                .ToList();
        }

        public RequestDevice GetById(int id)
        {
            return _context.RequestDevices
                .Include(r => r.Product)
                .Include(r => r.User)
                .OrderByDescending(s => s.UpDateTime)
                .FirstOrDefault(s => s.RequestDeviceId == id);
        }

        public int Add(RequestDevice requestDevice)
        {
            _context.RequestDevices.Add(requestDevice);
            _context.SaveChanges();
            return requestDevice.RequestDeviceId;
        }

        public void Update(RequestDevice requestDevice)
        {
            _context.RequestDevices.Update(requestDevice);
            _context.SaveChanges();
        }

        public void Delete(RequestDevice requestDevice)
        {
           requestDevice.IsDelete=true;
           Update(requestDevice);
        }

        public bool Exist(int id)
        {
            return _context.RequestDevices.Any(s=>s.RequestDeviceId == id);
        }

        public Tuple<List<RequestDevice>, int> GetAll(int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.RequestDevices.Count();
            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }
            var query = _context.RequestDevices
                .Include(r => r.Product)
                .Include(r => r.User)
                .OrderByDescending(s => s.ViewStatus == false)
                .ThenByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public Tuple<List<RequestDevice>, int> GetRequestDeViceBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.RequestDevices
                .Include(r => r.Product)
                .Include(r => r.User)
                .Count(
                s=>s.Description.ToLower().Contains(search)
                || s.User.FullName.ToLower().Contains(search)
                || s.User.PhoneNumber.ToLower().Contains(search)
                || s.Product.Name.ToLower().Contains(search)
                || s.Product.ProductGroup.GroupName.ToLower().Contains(search)
                
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
            var query = _context.RequestDevices
                .Include(r => r.Product)
                .Include(r => r.User)
                .Where(
                    s => s.Description.ToLower().Contains(search)
                         || s.User.FullName.ToLower().Contains(search)
                         || s.User.PhoneNumber.ToLower().Contains(search)
                         || s.Product.Name.ToLower().Contains(search)
                         || s.Product.ProductGroup.GroupName.ToLower().Contains(search)
                         && s.ViewStatus== false
                )
                .OrderByDescending(s => s.UpDateTime)
                .Skip(skip)
                .Take(take);
            return Tuple.Create(query.ToList(), pageCount);
        }

        public int RequestCount()
        {
            return _context.RequestDevices.Count();
        }

        public List<RequestDevice> GetRequestByUserId(string id)
        {
            return _context.RequestDevices
                .Include(s => s.User)
                .Include(s => s.Product)
                .Where(s => s.UserId == id)
                .ToList();
        }

        public int SumRequestNotComplete()
        {
            return _context.RequestDevices
                .Count(s => s.ViewStatus == false);
        }
    }
}
