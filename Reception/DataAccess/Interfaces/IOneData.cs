using System.Collections.Generic;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IOneData
    {
        List<OneData> GetAll();
        OneData GetById(int id);
        OneData GetFirst();
        void Add(OneData oneData);
        void Delete(OneData oneData);
        void Update(OneData oneData);
        bool Exist(int id);

    }
}
