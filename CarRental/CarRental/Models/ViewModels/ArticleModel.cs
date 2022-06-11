using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Models.ViewModels
{
    public class ArticleModel
    {
        public Blog Blog { get; set; }
        public List<Comment> Comments { get; set; }
    }
}