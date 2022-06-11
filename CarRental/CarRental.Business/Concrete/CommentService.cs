using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class CommentService : CoreService<Comment, ICommentDal>, ICommentService
    {
        public CommentService(ICommentDal commentDal) : base(commentDal)
        {
        }
    }
}