using CarRental.Core.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Entity.Concrete
{
    public class Device : CoreEntity
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }

        public List<DeviceMovement> DeviceMovements { get; set; }
    }
}