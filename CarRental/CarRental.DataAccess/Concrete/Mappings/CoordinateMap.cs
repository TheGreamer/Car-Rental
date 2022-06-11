using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class CoordinateMap : EntityTypeConfiguration<Coordinate>
    {
        public CoordinateMap()
        {
            ToTable("Coordinates");

            Property(c => c.Latitude).IsRequired();
            Property(c => c.Longitude).IsRequired();
        }
    }
}