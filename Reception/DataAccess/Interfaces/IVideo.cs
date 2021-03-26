using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IVideo
    {
        Task<List<Video>> GetAll();
        Task<Video> GetById(int id);
        void Add(Video video);
        void Update(Video video);
        void Delete(Video video);
        bool Exist(int id);
    }
}
