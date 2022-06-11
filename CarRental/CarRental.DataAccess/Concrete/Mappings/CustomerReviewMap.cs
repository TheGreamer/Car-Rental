using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class CustomerReviewMap : EntityTypeConfiguration<CustomerReview>
    {
        public CustomerReviewMap()
        {
            ToTable("CustomerReviews");

            Property(c => c.Name).IsRequired();
            Property(c => c.Location).IsRequired();
            Property(c => c.Image).IsRequired();
            Property(c => c.Review).IsRequired();
        }
    }
}