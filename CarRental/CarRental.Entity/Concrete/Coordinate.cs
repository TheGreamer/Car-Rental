using CarRental.Core.Entity.Concrete;

namespace CarRental.Entity.Concrete
{
    public class Coordinate : CoreEntity
    {
        public int ShipmentId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Shipment Shipment { get; set; }
    }
}