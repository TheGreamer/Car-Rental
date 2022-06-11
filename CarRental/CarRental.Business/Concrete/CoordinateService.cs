using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class CoordinateService : CoreService<Coordinate, ICoordinateDal>, ICoordinateService
    {
        public CoordinateService(ICoordinateDal coordinateDal) : base(coordinateDal)
        {
        }
    }
}