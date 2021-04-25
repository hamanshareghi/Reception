using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IAllMessage
    {
        void Add(AllMessage allMessage);

        Tuple<List<AllMessage>, int> GetAll(int take,int pageId=1);

        int GetAllMessageCount();
        Tuple<List<AllMessage>, int> GetUserMessage(string id,int take,int pageId=1);
        Tuple<List<AllMessage>, int> GetMessageBySearch(string search, int take, int pageId = 1);
        AllMessage GetById(int id);

        void Update(AllMessage allMessage);
        void Delete(AllMessage allMessage);
        bool Exist(int id);
    }
}
