using System.Collections.Generic;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IBrand
    {
        List<Brand> GetAll(int count);
        Brand GetById(int id);
  
        void Add(Brand brand);  
        void Delete(Brand brand);
        void Update(Brand brand);
        bool Exist(int id);
    }
}
