using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IShipping
    {
        Task<List<Shipping>> GetAll();
        Task<Shipping> GetById(int id);
        void Add(Shipping shipping);
        void Update(Shipping shipping);
        void Delete(Shipping shipping);
        bool Exist(int id);
    }
}
