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
        Tuple<List<Shipping>,int>  GetAll(int pageId=1);
        Task<Shipping> GetById(int id);
        void Add(Shipping shipping);
        void Update(Shipping shipping);
        void Delete(Shipping shipping);
        bool Exist(int id);
        Tuple<List<Shipping>, int> GetShippingBySearch(string search,int pageId);

    }
}
