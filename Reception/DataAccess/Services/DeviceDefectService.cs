﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DataAccess.Services
{
    public class DeviceDefectService : IDeviceDefect
    {
        private DataContext _context;

        public DeviceDefectService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<DeviceDefect> GetAll()
        {
            return _context.DeviceDefects.ToList();
        }

        public DeviceDefect GetById(int id)
        {
            return _context.DeviceDefects.FirstOrDefault(s => s.DeviceDefectId == id);
        }

        public void Add(DeviceDefect deviceDefect)
        {
            _context.DeviceDefects.Add(deviceDefect);
            _context.SaveChanges();
        }

        public List<DeviceDefect> GetDefectsByReception(int id)
        {
            return _context.DeviceDefects
                .Include(s=>s.Defect)
                .Where(s => s.ReceptionId == id)
                .OrderByDescending(s => s.InsertDate)
                .ToList();

        }
    }
}
