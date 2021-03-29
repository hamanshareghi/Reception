using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IDuty
    {
        Task<List<Duty>> GetAll();
        Task<Duty> GetById(int id);
        void Add(Duty duty);
        void Update(Duty duty);
        void Delete(Duty duty);
        bool Exist(int id);
    }
}
