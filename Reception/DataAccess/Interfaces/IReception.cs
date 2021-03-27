using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IReception
    {
        Task<List<Reception>> GetAll();
        Task<Reception> GetById(int id);
        void Add(Reception reception);
        void Update(Reception reception);
        void Delete(Reception reception);
        bool Exist(int id);
    }
}
