using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class FaqService : CoreService<Faq, IFaqDal>, IFaqService
    {
        public FaqService(IFaqDal faqDal) : base(faqDal)
        {
        }
    }
}