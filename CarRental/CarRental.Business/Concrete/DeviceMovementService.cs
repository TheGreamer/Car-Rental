using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class DeviceMovementService : CoreService<DeviceMovement, IDeviceMovementDal>, IDeviceMovementService
    {
        public DeviceMovementService(IDeviceMovementDal deviceMovementDal) : base(deviceMovementDal)
        {
        }
    }
}