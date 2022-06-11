using CarRental.Core.Entity.Concrete;

namespace CarRental.Entity.Concrete
{
    public class CustomerReview : CoreEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public string Review { get; set; }
    }
}