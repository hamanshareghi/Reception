using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface ICustomer
    {
        Tuple<List<ApplicationUser>,int> GetAll(int pageId=1);
        Tuple<List<ApplicationUser>,int> GetUserBySearch(string search,int pageId=1);
    }
}
