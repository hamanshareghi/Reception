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

        Tuple<List<AllMessage>, int> GetAll();

        int GetAllMessageCount();
    }
}
