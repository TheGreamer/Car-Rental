using CarRental.Areas.Admin.Models.ViewModels;
using CarRental.Business.Abstract;
using CarRental.Controllers;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace CarRental.Areas.Admin.Controllers
{
    [AdminCheck]
    public class DashboardController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICustomerReviewService _customerReviewService;
        private readonly IBlogService _blogService;
        private readonly IFaqService _faqService;
        private readonly ITeamMemberService _teamMemberService;
        private readonly IPricingPlanService _pricingPlanService;
        private readonly IPartnerService _partnerService;
        private readonly IMessageService _messageService;
        private readonly IIotCarService _iotCarService;
        private readonly IDriverService _driverService;
        private readonly ICoordinateService _coordinateService;
        private readonly IShipmentService _shipmentService;

        public DashboardController(ICarService carService, ICustomerReviewService customerReviewService, IBlogService blogService, IFaqService faqService, ITeamMemberService teamMemberService, IPricingPlanService pricingPlanService, IPartnerService partnerService, IMessageService messageService, IIotCarService iotCarService, IDriverService driverService, ICoordinateService coordinateService, IShipmentService shipmentService)
        {
            _carService = carService;
            _customerReviewService = customerReviewService;
            _blogService = blogService;
            _faqService = faqService;
            _teamMemberService = teamMemberService;
            _pricingPlanService = pricingPlanService;
            _partnerService = partnerService;
            _messageService = messageService;
            _iotCarService = iotCarService;
            _driverService = driverService;
            _coordinateService = coordinateService;
            _shipmentService = shipmentService;
        }

        public ActionResult Index() => View(new DashboardModel()
        {
            PageCount = typeof(HomeController)
                        .Assembly.GetTypes()
                        .Where(t => typeof(Controller).IsAssignableFrom(t) && t.Namespace.StartsWith("CarRental"))
                        .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                        .Where(m => typeof(ActionResult).IsAssignableFrom(m.ReturnType) && !m.IsAbstract && m.GetCustomAttribute<NonActionAttribute>() == null && m.GetCustomAttribute<HttpPostAttribute>() == null)
                        .Count(),
            CarCount = _carService.GetCount(),
            BlogCount = _blogService.GetCount(),
            CustomerReviewCount = _customerReviewService.GetCount(),
            FaqCount = _faqService.GetCount(),
            MessageCount = _messageService.GetCount(),
            PartnerCount = _partnerService.GetCount(),
            PricingPlanCount = _pricingPlanService.GetCount(),
            TeamMemberCount = _teamMemberService.GetCount(),
            IotCarCount = _iotCarService.GetCount(),
            DriverCount = _driverService.GetCount(),
            ActiveShipmentCount = _shipmentService.GetCount(a => a.ShipmentState == ShipmentState.Active),
            CompletedShipmentCount = _shipmentService.GetCount(a => a.ShipmentState == ShipmentState.Completed),
            WaitingShipmentCount = _shipmentService.GetCount(a => a.ShipmentState == ShipmentState.Waiting),
            PreparingShipmentCount = _shipmentService.GetCount(a => a.ShipmentState == ShipmentState.Preparing),
            Shipments = _shipmentService.GetAll(),
            IotCars = _iotCarService.GetAll(),
            Drivers = _driverService.GetAll(),
        });
    }
}