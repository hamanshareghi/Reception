using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IRequestDevice
    {
        Task<List<RequestDevice>> GetAll();
        Task<RequestDevice> GetById(int id);
        void Add(RequestDevice requestDevice);
        void Update(RequestDevice requestDevice);
        void Delete(RequestDevice requestDevice);
        bool Exist(int id);

    }
}
