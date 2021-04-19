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

        public Tuple<List<AllMessage>, int> GetAll()
        {
            throw new NotImplementedException();
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
    }
}
