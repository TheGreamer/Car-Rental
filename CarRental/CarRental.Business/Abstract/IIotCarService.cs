using CarRental.Core.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Abstract
{
    public interface IIotCarService : ICoreService<IotCar, IIotCarDal>
    {
    }
}