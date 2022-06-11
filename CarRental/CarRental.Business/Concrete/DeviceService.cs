using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class DeviceService : CoreService<Device, IDeviceDal>, IDeviceService
    {
        public DeviceService(IDeviceDal deviceDal) : base(deviceDal)
        {
        }
    }
}