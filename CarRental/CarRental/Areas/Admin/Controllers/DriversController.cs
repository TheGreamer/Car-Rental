using CarRental.Business.Abstract;
using CarRental.Core.MvcUI.Concrete;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;

namespace CarRental.Areas.Admin.Controllers
{
    [AdminCheck]
    public class DriversController : BaseController<Driver, IDriverService>
    {
        public DriversController(IDriverService driverService) : base(driverService)
        {
        }
    }
}