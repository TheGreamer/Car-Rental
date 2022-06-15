using CarRental.Business.Abstract;
using CarRental.Core.Entity.Concrete;
using CarRental.Core.MvcUI.Concrete;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;
using CarRental.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

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
                Users = _userService.GetAll()
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
            commentToAdd.BlogId = comment.BlogId;

            _commentService.Add(comment);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}