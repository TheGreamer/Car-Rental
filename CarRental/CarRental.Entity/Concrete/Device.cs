using CarRental.Core.Entity.Concrete;

namespace CarRental.Entity.Concrete
{
    public class Device : CoreEntity
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
    }
}