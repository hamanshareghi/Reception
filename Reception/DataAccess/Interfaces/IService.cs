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
        List<Service> GetAll();
        Tuple<List<Service>,int> GetAll(int take,int pageId=1);
        Task<Service> GetById(int id);
        void Add(Service service);
        void Update(Service service);
        void Delete(Service service);
        bool Exist(int id);
        Tuple<List<Service>, int> GetServiceBySearch(string search, int take, int pageId = 1);
    }
}
