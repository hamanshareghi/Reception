using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICost
    {
        Task<List<Cost>> GetAll();
        Task<Cost> GetById(int id);
        void Add(Cost cost);
        void Update(Cost cost);
        void Delete(Cost cost);
        bool Exist(int id);
    }
}
