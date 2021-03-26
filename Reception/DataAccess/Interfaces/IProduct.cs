using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IProduct
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product ,IFormFile imgUp);
        void Delete(Product product);
        void Update(Product product);
        bool Exist(int id);
        List<Product> GetProducts(string query);

        List<Product> GetProductByGroup(int id);
        List<Product> GetProductByCount(int count = 0);
        //void UpdateVisitCount(Product product);
        //List<Product> GetSpecial(int count);
        bool ProductExist();

        //bool ShortKeyExist(string shortKey);
        //Product GetByShortKey(string shortKey);
        //Tuple<Product, Product> GetTwoProductForOffer();
        //Product GetFirstOffer();
        //Product GetSecondOffer();

    }
}
