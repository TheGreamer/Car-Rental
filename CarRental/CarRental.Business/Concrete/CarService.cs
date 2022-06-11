using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class CarService : CoreService<Car, ICarDal>, ICarService
    {
        public CarService(ICarDal carDal) : base(carDal)
        {
        }
    }
}