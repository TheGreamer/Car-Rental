using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class PricingPlanMap : EntityTypeConfiguration<PricingPlan>
    {
        public PricingPlanMap()
        {
            ToTable("PricingPlans");

            Property(p => p.Title).IsRequired();
            Property(p => p.Price).IsRequired();
            Property(p => p.SearchAllListings).IsRequired();
            Property(p => p.CreateWishlist).IsRequired();
            Property(p => p.SeeSellerContact).IsRequired();
            Property(p => p.FullListingInfo).IsRequired();
        }
    }
}