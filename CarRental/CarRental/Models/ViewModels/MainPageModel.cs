using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Models.ViewModels
{
    public class MainPageModel : CarListModel
    {
        public List<CustomerReview> CustomerReviews { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Comment> Comments { get; set; }
    }
}