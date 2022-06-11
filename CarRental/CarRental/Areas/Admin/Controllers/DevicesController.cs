using CarRental.Business.Abstract;
using CarRental.Core.MvcUI.Concrete;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;

namespace CarRental.Areas.Admin.Controllers
{
    [AdminCheck]
    public class DevicesController : BaseController<Device, IDeviceService>
    {
        public DevicesController(IDeviceService deviceService) : base(deviceService)
        {
        }
    }
}