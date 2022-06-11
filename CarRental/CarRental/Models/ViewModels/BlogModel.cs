using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Models.ViewModels
{
    public class BlogModel
    {
        public List<Blog> Blog { get; set; }
        public List<Comment> Comments { get; set; }
    }
}