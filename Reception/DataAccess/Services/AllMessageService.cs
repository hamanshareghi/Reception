using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using DataAccess.Interfaces;
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
    }
}
