using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DataAccess.Interfaces
{
    public interface IDeviceDefect
    {
        IEnumerable<DeviceDefect> GetAll();
        DeviceDefect GetById(int id);
        void Add(DeviceDefect deviceDefect);
    }
}
