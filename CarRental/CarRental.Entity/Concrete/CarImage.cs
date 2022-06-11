using CarRental.Core.Entity.Concrete;

namespace CarRental.Entity.Concrete
{
    public class CarImage : CoreEntity
    {
        public int CarId { get; set; }
        public string Image { get; set; }

        public Car Car { get; set; }
    }
}