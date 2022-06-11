using CarRental.Business.Abstract;
using CarRental.Core.Entity.Concrete;
using CarRental.Core.MvcUI.Concrete;
using CarRental.Entity.Concrete;
using CarRental.Models.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarImageService _carImageService;
        private readonly ICustomerReviewService _customerReviewService;
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        private readonly IFaqService _faqService;
        private readonly ITeamMemberService _teamMemberService;
        private readonly IPricingPlanService _pricingPlanService;
        private readonly IPartnerService _partnerService;
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public HomeController(ICarService carService, ICarImageService carImageService, ICustomerReviewService customerReviewService, IBlogService blogService, ICommentService commentService, IFaqService faqService, ITeamMemberService teamMemberService, IPricingPlanService pricingPlanService, IPartnerService partnerService, IMessageService messageService, IUserService userService)
        {
            _carService = carService;
            _carImageService = carImageService;
            _customerReviewService = customerReviewService;
            _blogService = blogService;
            _commentService = commentService;
            _faqService = faqService;
            _teamMemberService = teamMemberService;
            _pricingPlanService = pricingPlanService;
            _partnerService = partnerService;
            _messageService = messageService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Index() => View(new MainPageModel()
        {
            Cars = _carService.GetAll(c => c.Status == Status.Active).Take(6).ToList(),
            CarImages = _carImageService.GetAll(c => c.Status == Status.Active),
            CustomerReviews = _customerReviewService.GetAll(c => c.Status == Status.Active),
            Blogs = _blogService.GetAll(b => b.Status == Status.Active).OrderByDescending(b => b.Id).Take(6).ToList(),
            Comments = _commentService.GetAll(c => c.Status == Status.Active)
        });

        [HttpGet]
        public ActionResult Faq() => View(_faqService.GetAll(f => f.Status == Status.Active));

        [HttpGet]
        public ActionResult About() => View(new AboutPageModel()
        {
            TeamMembers = _teamMemberService.GetAll(t => t.Status == Status.Active),
            CustomerReviews = _customerReviewService.GetAll(c => c.Status == Status.Active)
        });

        [HttpGet]
        public ActionResult Pricing() => View(new PricingPageModel()
        {
            PricingPlans = _pricingPlanService.GetAll(p => p.Status == Status.Active),
            Partners = _partnerService.GetAll(p => p.Status == Status.Active)
        });

        [HttpGet]
        public ActionResult Contact() => View(new ContactModel()
        {
            Partners = _partnerService.GetAll(p => p.Status == Status.Active)
        });

        [HttpPost]
        public ActionResult Contact(Message message)
        {
            if (ModelState.IsValid)
            {
                _messageService.Add(message);
                return Content(Utility.RedirectWithMessage("Mesajınız iletildi. Anasayfaya yönlendiriliyorsunuz."));
            }

            return View(new ContactModel()
            {
                Partners = _partnerService.GetAll(p => p.Status == Status.Active)
            });
        }

        [HttpGet]
        public ActionResult Privacy() => View();

        [HttpGet]
        public ActionResult SignIn()
        {
            if (string.IsNullOrEmpty(HttpContext.User.Identity.Name))
                FormsAuthentication.SignOut();

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User user)
        {
            User loggedInUser = _userService.Get(u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password) && u.Status == Status.Active);

            if (loggedInUser != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return loggedInUser.Role == Role.User ? RedirectToAction("Index") : (ActionResult)Redirect("/Admin/Dashboard");
            }

            ViewBag.SignInError = "Kullanıcı adı ve şifre uyuşmuyor.";
            return View(user);
        }

        [HttpGet]
        public ActionResult SignUp() => View();

        [HttpPost]
        public ActionResult SignUp(User user, HttpPostedFileBase userImage)
        {
            if (ModelState.IsValid)
            {
                if (_userService.GetCount(u => u.UserName == user.UserName) > 0)
                    return Content(Utility.RedirectWithMessage("Bu kullanıcı adı kullanılmış.", "Home", "SignUp", messageType: MessageType.error));

                if (_userService.GetCount(u => u.Email == user.Email) > 0)
                    return Content(Utility.RedirectWithMessage("Bu e-posta adresi kullanılmış.", "Home", "SignUp", messageType: MessageType.error));

                user.Role = Role.User;
                user.Image = userImage != null ? Utility.SaveFile(userImage, Server.MapPath("~/Content/img/avatars/")) : "default-user.png";

                _userService.Add(user);
                return Content(Utility.RedirectWithMessage("Kayıt oldunuz. Girişe yönlendiriliyorsunuz.", "Home", "SignIn"));
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }
    }
}