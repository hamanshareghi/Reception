﻿using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICostDefine
    {
        IEnumerable<CostDefine> GetAll();
        Task<CostDefine> GetById(int id);
        void Add(CostDefine costDefine);
        void Update(CostDefine costDefine);
        void Delete(CostDefine costDefine);
        bool Exist(int id);
    }
}