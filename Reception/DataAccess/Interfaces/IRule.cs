using System;
using System.Collections.Generic;
using Model.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRule
    {
        Task<List<Rule>> GetAll();
        Task<Rule> GetById(int id);
        void Add(Rule rule);
        void Update(Rule rule);
        void Delete(Rule rule);
        bool Exist(int id);
        Task<Rule> GetFirst();
    }
}
