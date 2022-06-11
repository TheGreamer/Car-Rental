using CarRental.DataAccess.Concrete.Contexts;
using CarRental.Entity.Concrete;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarRental.CustomAttributes
{
    public class AdminCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            using (EfContext context = new EfContext())
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (context.Users.ToList().FirstOrDefault(u => u.UserName == (HttpContext.Current.User.Identity as FormsIdentity).Name).Role != Role.Admin)
                        filterContext.HttpContext.Response.Redirect("/Home");
                }
                else
                    filterContext.HttpContext.Response.Redirect("/Home/SignIn");
            }
        }
    }
}