﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IReception
    {
        List<Reception> GetAll();
        Reception GetById(int id);
        int Add(Reception reception);
        void Update(Reception reception);
        void Delete(Reception reception);
        bool Exist(int id);
        Tuple<List<Reception>, int> GetAll(int take, int pageId = 1);
        Tuple<List<Reception>, int> GetReceptionBySearch(string search,int take, int pageId = 1);
    }
}
