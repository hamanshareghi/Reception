using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IPayType
    {
        Tuple<List<PayType>, int> GetAll(int take, int pageId = 1);
        Tuple<List<PayType>, int> GetPayTypeBySearch(string search, int take, int pageId = 1);
        List<PayType> GetAll();
        void Add(PayType payType);
        void Update(PayType payType);
        void Delete(PayType payType);
        bool Exist(int id);
        PayType GetById(int id);
    }
}
