using CarRental.Business.Abstract;
using CarRental.Core.MvcUI.Concrete;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;

namespace CarRental.Areas.Admin.Controllers
{
    [AdminCheck]
    public class FaqsController : BaseController<Faq, IFaqService>
    {
        public FaqsController(IFaqService faqService) : base(faqService)
        {
        }
    }
}