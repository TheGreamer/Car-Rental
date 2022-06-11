using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class FaqMap : EntityTypeConfiguration<Faq>
    {
        public FaqMap()
        {
            ToTable("Faqs");

            Property(f => f.Question).IsRequired();
            Property(f => f.Answer).IsRequired();
        }
    }
}