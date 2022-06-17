using CarRental.Business.Abstract;
using CarRental.Core.Entity.Concrete;
using CarRental.Core.MvcUI.Concrete;
using CarRental.Entity.Concrete;
using CarRental.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public BlogController(IBlogService blogService, ICommentService commentService, IUserService userService)
        {
            _blogService = blogService;
            _commentService = commentService;
            _userService = userService;
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
                Comments = _commentService.GetAll(c => c.BlogId == id && c.Status == Status.Active).ToList(),
                Users = _userService.GetAll(),
                UserService = _userService
            };

            if (model.Blog == null)
            {
                ViewBag.ErrorMessage = "Makale bulunamadı.";
                return View("Error");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SendComment(Comment comment, string userName)
        {
            Comment commentToAdd = comment;
            commentToAdd.Date = DateTime.Now;
            commentToAdd.UserId = _userService.Get(u => u.UserName == userName).Id;

            _commentService.Add(comment);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult DeleteComment(int? id)
        {
            if (id == null || !User.Identity.IsAuthenticated)
                return RedirectToAction("Index");

            if (_userService.Get(u => u.UserName == User.Identity.Name).Role == Role.Admin)
                _commentService.Delete(_commentService.GetById((int)id));

            if (Request.UrlReferrer != null)
                return Redirect(Request.UrlReferrer.ToString());

            return RedirectToAction("Index");
        }
    }
}