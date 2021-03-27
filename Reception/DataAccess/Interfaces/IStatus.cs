using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IStatus
    {
        Task<List<Status>> GetAll();
        Task<Status> GetById(int id);
        void Add(Status status);
        void Update(Status status);
        void Delete(Status status);
        bool Exist(int id);
    }
}
