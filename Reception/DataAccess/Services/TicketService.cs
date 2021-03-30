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
    public class TicketService : ITicket
    {
        private DataContext _context;

        public TicketService(DataContext context)
        {
            _context = context;
        }
        public Task<List<Ticket>> GetAll()
        {
           return _context.Tickets
                .Include(s => s.User)
                .OrderByDescending(s => s.UpDateTime)
                .ToListAsync();
        }

        public Task<Ticket> GetById(int id)
        {
            return _context.Tickets
                .Include(s => s.User)
                .OrderByDescending(s => s.UpDateTime)
                .FirstOrDefaultAsync(s => s.TicketId == id);
        }

        public void Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }

        public void Delete(Ticket ticket)
        {
            ticket.IsDelete = true;
           Update(ticket);
            
        }

        public bool Exist(int id)
        {
            return _context.Tickets.Any(s => s.TicketId == id);
        }
    }
}
