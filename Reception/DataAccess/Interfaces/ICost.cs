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
        List<Cost> GetAll();
        Task<Cost> GetById(int id);
        void Add(Cost cost);
        void Update(Cost cost);
        void Delete(Cost cost);
        bool Exist(int id);
        Tuple<List<Cost>, int> GetAll(int take, int pageId = 1);
        Tuple<List<Cost>, int> GetCostBySearch(string search,int take, int pageId = 1);

        List<Cost> GetCostFromToDate(string search, string strDate, string endDate);
    }
}
