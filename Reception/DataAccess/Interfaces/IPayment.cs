using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IPayment
    {
        List<Payment> GetAll();
        Tuple<List<Payment>,int> GetAll(int take,int pageId=1);
        Tuple<List<Payment>,int> GetPaymentBySearch(string search,int take,int pageId=1);
        Payment GetById(int id);
        void Add(Payment payment);
        void Update(Payment payment);
        void Delete(Payment payment);
        bool Exist(int id);

    }
}
