using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class CarImageService : CoreService<CarImage, ICarImageDal>, ICarImageService
    {
        public CarImageService(ICarImageDal carImageDal) : base(carImageDal)
        {
        }
    }
}