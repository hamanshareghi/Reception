using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDebtor
    {
        List<Debtor> GetAll();
        Tuple<List<Debtor>,int> GetAll(int take, int pageId = 1);
        Task<Debtor> GetById(int id);
        void Add(Debtor debtor);
        void Update(Debtor debtor);
        void Delete(Debtor debtor);
        bool Exist(int id);
        Tuple<List<Debtor>, int> GetDebtorBySearch(string search,int take,int pageId);
    }
}
