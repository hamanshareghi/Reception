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
        List<RequestDevice> GetAll();
        RequestDevice GetById(int id);
        int Add(RequestDevice requestDevice);
        void Update(RequestDevice requestDevice);
        void Delete(RequestDevice requestDevice);
        bool Exist(int id);
        Tuple<List<RequestDevice>, int> GetAll(int take, int pageId = 1);
        Tuple<List<RequestDevice>, int> GetRequestDeViceBySearch(string search,int take, int pageId = 1);
        int RequestCount();
    }
}
