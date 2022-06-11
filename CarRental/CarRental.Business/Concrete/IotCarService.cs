using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class IotCarService : CoreService<IotCar, IIotCarDal>, IIotCarService
    {
        public IotCarService(IIotCarDal iotCarDal) : base(iotCarDal)
        {
        }
    }
}