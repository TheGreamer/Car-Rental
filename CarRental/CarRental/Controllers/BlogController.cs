using CarRental.Business.Abstract;
using CarRental.Core.Entity.Concrete;
using CarRental.Core.MvcUI.Concrete;
using CarRental.Models.ViewModels;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;

        public BlogController(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }

        [HttpGet]
        public ActionResult Index() => View(new BlogModel()
        {
            Blog = _blogService.GetAll(b => b.Status == Status.Active),
            Comments = _commentService.GetAll(c => c.Status == Status.Active)
        });

        [HttpGet]
        public ActionResult Articles(int? id)
        {
            if (id == null)
                return Content(Utility.RedirectWithMessage("Hatalı işlem gerçekleşti. Blog sayfasına yönlendiriliyorsunuz.", "Blog"));

            ArticleModel model = new ArticleModel()
            {
                Blog = _blogService.GetById((int)id),
                Comments = _commentService.GetAll(c => c.BlogId == id && c.Status == Status.Active)
            };

            if (model.Blog == null)
            {
                ViewBag.ErrorMessage = "Makale bulunamadı.";
                return View("Error");
            }

            return View(model);
        }
    }
}