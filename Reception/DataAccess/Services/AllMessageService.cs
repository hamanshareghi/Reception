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
    public class AllMessageService : IAllMessage
    {
        private DataContext _context;

        public AllMessageService(DataContext context)
        {
            _context = context;
        }
        public void Add(AllMessage allMessage)
        {
            _context.AllMessages.Add(allMessage);
            _context.SaveChanges();
        }

        public Tuple<List<AllMessage>, int> GetAll(int take,int pageId=1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.AllMessages.Count();

            if (pageCount % take != 0)
            {
                pageCount = pageCount / take;
                pageCount++;
            }
            else
            {
                pageCount = pageCount / take;
            }

            var query = _context.AllMessages
                .Include(s => s.Users)
                .OrderByDescending(s=>s.SmsDate)
                .Skip(skip)
                .Take(take);

            return Tuple.Create(query.ToList(), pageCount);
        }

        public int GetAllMessageCount()
        {
          return  _context.AllMessages.Count();
        }

        public Tuple<List<AllMessage>, int> GetUserMessage(string id, int take, int pageId = 1)
        {
            int skip=(pageId-1)*take;
            int pageCount = _context.AllMessages.Count(
                s=>s.UserId == id
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

            var query = _context.AllMessages
                .Include(s => s.Users)
                .Where(s => s.UserId == id)
                .OrderByDescending(s=>s.SmsDate);
            return Tuple.Create(query.ToList(),pageCount);

        }

        public Tuple<List<AllMessage>, int> GetMessageBySearch(string search, int take, int pageId = 1)
        {
            int skip = (pageId - 1) * take;
            int pageCount = _context.AllMessages.Count(
                s => s.Description.Contains(search)
                ||s.SmsStatus.ToLower().Contains(search)
                || s.Users.FullName.ToLower().Contains(search)
                || s.Users.PhoneNumber.ToLower().Contains(search)

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

            var query = _context.AllMessages
                .Include(s => s.Users)
                .Where(s => s.Description.Contains(search)
                            || s.SmsStatus.ToLower().Contains(search)
                            || s.Users.FullName.ToLower().Contains(search)
                            || s.Users.PhoneNumber.ToLower().Contains(search)
                )
                .OrderByDescending(s => s.SmsDate)
                .Skip(skip)
                .Take(take);

            return Tuple.Create(query.ToList(), pageCount);
        }

        public AllMessage GetById(int id)
        {
            return _context.AllMessages.FirstOrDefault(s => s.SmsId == id);
        }

        public void Update(AllMessage allMessage)
        {
            _context.AllMessages.Update(allMessage);
            _context.SaveChanges();
        }

        public void Delete(AllMessage allMessage)
        {
            allMessage.IsDelete = true;
            Update(allMessage);
        }

        public bool Exist(int id)
        {
            return _context.AllMessages.Any(s => s.SmsId == id);
        }
    }
}
