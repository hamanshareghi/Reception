using System;
using System.Collections.Generic;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IBrand
    {
        Tuple<List<Brand>,int> GetAll(int take,int pageId=1);
        Tuple<List<Brand>, int> GetBrandBySearch(string search, int take, int pageId = 1);
        Brand GetById(int id);
  
        void Add(Brand brand);  
        void Delete(Brand brand);
        void Update(Brand brand);
        bool Exist(int id);

        List<Brand> GetAll();
    }
}
