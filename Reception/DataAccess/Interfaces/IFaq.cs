using System;
using System.Collections.Generic;
using System.Text;


using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IFaq
    {
        List<Faq> GetAll();
        Faq GetById(int id);
        void Add(Faq faq);
        void Update(Faq faq);
        void Delete(Faq faq);
        void Save();
        bool Exist(int id);
        Faq GetFirst();
        List<Faq> GetAllWithOutFirst();
        int GetAllFaqCount();

    }
}
