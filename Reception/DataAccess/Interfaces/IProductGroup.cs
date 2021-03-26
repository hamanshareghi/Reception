using System.Collections.Generic;
using Model.Entities;


namespace DataAccess.Interfaces
{
    public interface IProductGroup
    {
        List<ProductGroup> GetAll();
        ProductGroup GetById(int id);
        void Add(ProductGroup productGroup);
        void Update(ProductGroup productGroup);
        void Delete(ProductGroup productGroup);
        bool Exist(int id);
    }
}
