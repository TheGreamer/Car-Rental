using CarRental.Core.Entity.Concrete;

namespace CarRental.Entity.Concrete
{
    public class PricingPlan : CoreEntity
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public bool SearchAllListings { get; set; }
        public bool CreateWishlist { get; set; }
        public bool SeeSellerContact { get; set; }
        public bool FullListingInfo { get; set; }
    }
}