using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class DeviceMovementMap : EntityTypeConfiguration<DeviceMovement>
    {
        public DeviceMovementMap()
        {
            ToTable("DeviceMovements");

            Property(c => c.Latitude).IsRequired();
            Property(c => c.Longitude).IsRequired();
            Property(c => c.CurrentDate).IsRequired();
            Property(c => c.IsGoing).IsRequired();
        }
    }
}