using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class DriverService : CoreService<Driver, IDriverDal>, IDriverService
    {
        public DriverService(IDriverDal driverDal) : base(driverDal)
        {
        }
    }
}