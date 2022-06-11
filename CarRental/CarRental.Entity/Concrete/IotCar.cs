using CarRental.Core.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Entity.Concrete
{
    public class IotCar : CoreEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleType { get; set; }

        public List<Shipment> Shipments { get; set; }
    }
}