using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class PartnerMap : EntityTypeConfiguration<Partner>
    {
        public PartnerMap()
        {
            ToTable("Partners");

            Property(p => p.WebSite).IsRequired();
            Property(p => p.Image).IsRequired();
        }
    }
}