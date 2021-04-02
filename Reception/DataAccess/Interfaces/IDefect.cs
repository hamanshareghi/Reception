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
        List<Defect> GetAll();
        Tuple<List<Defect>,int> GetAll(int take,int pageId=1);
        Task<Defect> GetById(int id);
        void Add(Defect defect);
        void Update(Defect defect);
        void Delete(Defect defect);
        bool Exist(int id);
        Tuple<List<Defect>, int> GetDefectBySearch(string search, int take, int pageId = 1);
    }
}
