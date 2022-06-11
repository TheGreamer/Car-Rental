using CarRental.Core.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.DataAccess.Abstract
{
    public interface IPartnerDal : IEntityRepository<Partner>
    {
    }
}