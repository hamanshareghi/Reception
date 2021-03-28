using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public  interface ILeave
    {
        Task<List<Leave>> GetAll();
        Task<Leave> GetById(int id);
        void Add(Leave leave);
        void Update(Leave leave);
        void Delete(Leave leave);
        bool Exist(int id);
    }
}
