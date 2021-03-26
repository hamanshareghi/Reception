using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDefect
    {
        Task<List<Defect>> GetAll();
        Task<Defect> GetById(int id);
        void Add(Defect defect);
        void Update(Defect defect);
        void Delete(Defect defect);
        bool Exist(int id);
    }
}
