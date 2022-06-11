using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.DataAccessLayers;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CarRental
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<ICarService, CarService>();
            container.RegisterType<ICarImageService, CarImageService>();
            container.RegisterType<ICustomerReviewService, CustomerReviewService>();
            container.RegisterType<IBlogService, BlogService>();
            container.RegisterType<ICommentService, CommentService>();
            container.RegisterType<IFaqService, FaqService>();
            container.RegisterType<ITeamMemberService, TeamMemberService>();
            container.RegisterType<IPricingPlanService, PricingPlanService>();
            container.RegisterType<IPartnerService, PartnerService>();
            container.RegisterType<IMessageService, MessageService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IIotCarService, IotCarService>();
            container.RegisterType<IDriverService, DriverService>();
            container.RegisterType<ICoordinateService, CoordinateService>();
            container.RegisterType<IShipmentService, ShipmentService>();
            container.RegisterType<IDeviceService, DeviceService>();

            container.RegisterType<ICarDal, CarDal>();
            container.RegisterType<ICarImageDal, CarImageDal>();
            container.RegisterType<ICustomerReviewDal, CustomerReviewDal>();
            container.RegisterType<IBlogDal, BlogDal>();
            container.RegisterType<ICommentDal, CommentDal>();
            container.RegisterType<IFaqDal, FaqDal>();
            container.RegisterType<ITeamMemberDal, TeamMemberDal>();
            container.RegisterType<IPricingPlanDal, PricingPlanDal>();
            container.RegisterType<IPartnerDal, PartnerDal>();
            container.RegisterType<IMessageDal, MessageDal>();
            container.RegisterType<IUserDal, UserDal>();
            container.RegisterType<IIotCarDal, IotCarDal>();
            container.RegisterType<IDriverDal, DriverDal>();
            container.RegisterType<ICoordinateDal, CoordinateDal>();
            container.RegisterType<IShipmentDal, ShipmentDal>();
            container.RegisterType<IDeviceDal, DeviceDal>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}