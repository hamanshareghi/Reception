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
        Task<List<Debtor>> GetAll();
        Task<Debtor> GetById(int id);
        void Add(Debtor debtor);
        void Update(Debtor debtor);
        void Delete(Debtor debtor);
        bool Exist(int id);
    }
}
