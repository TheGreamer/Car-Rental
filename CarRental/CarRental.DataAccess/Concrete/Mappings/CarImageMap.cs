using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class CarImageMap : EntityTypeConfiguration<CarImage>
    {
        public CarImageMap()
        {
            ToTable("CarImages");

            Property(c => c.Image).IsRequired();
        }
    }
}