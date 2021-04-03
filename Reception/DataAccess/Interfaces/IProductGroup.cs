using System;
using System.Collections.Generic;
using Model.Entities;


namespace DataAccess.Interfaces
{
    public interface IProductGroup
    {
        List<ProductGroup> GetAll();
        Tuple<List<ProductGroup>,int> GetAll(int take,int pageId=1);
        ProductGroup GetById(int id);
        void Add(ProductGroup productGroup);
        void Update(ProductGroup productGroup);
        void Delete(ProductGroup productGroup);
        bool Exist(int id);
        Tuple<List<ProductGroup>, int> GetProductGroupBySearch(string search, int take, int pageId);
    }
}
