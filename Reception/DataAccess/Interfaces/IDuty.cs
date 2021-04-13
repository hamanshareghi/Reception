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
        List<Duty> GetAll();
        Duty GetById(int id);
        void Add(Duty duty);
        void Update(Duty duty);
        void Delete(Duty duty);
        bool Exist(int id);
        Tuple<List<Duty>, int> GetAll(int take, int pageId = 1);
        Tuple<List<Duty>, int> GetDutyBySearch(string search,int take, int pageId = 1);
    }
}
