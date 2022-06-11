using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class BlogService : CoreService<Blog, IBlogDal>, IBlogService
    {
        public BlogService(IBlogDal blogDal) : base(blogDal)
        {
        }
    }
}