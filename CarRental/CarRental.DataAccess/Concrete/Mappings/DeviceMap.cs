using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class DeviceMap : EntityTypeConfiguration<Device>
    {
        public DeviceMap()
        {
            ToTable("Devices");

            Property(d => d.Name).IsRequired();
            Property(d => d.SerialNumber).IsRequired();
        }
    }
}