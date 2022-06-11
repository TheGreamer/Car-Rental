using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class PricingPlanService : CoreService<PricingPlan, IPricingPlanDal>, IPricingPlanService
    {
        public PricingPlanService(IPricingPlanDal pricingPlanDal) : base(pricingPlanDal)
        {
        }
    }
}