using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface ISale
    {
        Tuple<List<Sale>, int> GetAll(int take,int pageId=1);
        Tuple<List<Sale>, int> GetSaleBySearch(string search, int take, int pageId = 1);
        int Add(Sale sale);
        void Update(Sale sale);
        void Delete(Sale sale);
        bool Exist(int id);
        Sale GetById(int id);
        bool ExitsShortKey(string shortKey);
    }
}
