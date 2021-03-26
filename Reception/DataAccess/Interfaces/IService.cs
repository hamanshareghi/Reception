using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IService
    {
        Task<List<Service>> GetAll();
        Task<Service> GetById(int id);
        void Add(Service service);
        void Update(Service service);
        void Delete(Service service);
        bool Exist(int id);
    }
}
