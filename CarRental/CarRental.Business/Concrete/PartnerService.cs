using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class PartnerService : CoreService<Partner, IPartnerDal>, IPartnerService
    {
        public PartnerService(IPartnerDal partnerDal) : base(partnerDal)
        {
        }
    }
}