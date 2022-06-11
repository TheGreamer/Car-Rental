using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class CustomerReviewService : CoreService<CustomerReview, ICustomerReviewDal>, ICustomerReviewService
    {
        public CustomerReviewService(ICustomerReviewDal customerReviewDal) : base(customerReviewDal)
        {
        }
    }
}