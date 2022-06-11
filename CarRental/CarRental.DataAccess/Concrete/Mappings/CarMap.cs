using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class CarMap : EntityTypeConfiguration<Car>
    {
        public CarMap()
        {
            ToTable("Cars");

            Property(c => c.Name).IsRequired();
            Property(c => c.Year).IsRequired();
            Property(c => c.MonthlyPayment).IsRequired();
            Property(c => c.CashIncentive).IsRequired();
            Property(c => c.TransferFee).IsRequired();
            Property(c => c.DispositionFee).IsRequired();
            Property(c => c.LeasingCompany).IsRequired();
            Property(c => c.LeaseEndDate).IsRequired();
            Property(c => c.SeatingCapacity).IsRequired();
            Property(c => c.GasolineType).IsRequired();
            Property(c => c.KilometersPerLiter).IsRequired();
            Property(c => c.GearType).IsRequired();
        }
    }
}