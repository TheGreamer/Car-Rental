using CarRental.Business.Abstract;
using CarRental.Core.MvcUI.Concrete;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;

namespace CarRental.Areas.Admin.Controllers
{
    [AdminCheck]
    public class IotCarsController : BaseController<IotCar, IIotCarService>
    {
        public IotCarsController(IIotCarService iotCarService) : base(iotCarService)
        {
        }
    }
}