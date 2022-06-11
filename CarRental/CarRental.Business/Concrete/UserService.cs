using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class UserService : CoreService<User, IUserDal>, IUserService
    {
        public UserService(IUserDal userDal) : base(userDal)
        {
        }
    }
}