using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface ITicket
    {
        Task<List<Ticket>> GetAll();
        Ticket GetById(int id);
        void Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(Ticket ticket);
        bool Exist(int id);

    }
}
