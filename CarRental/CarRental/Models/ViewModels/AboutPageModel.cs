using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Models.ViewModels
{
    public class AboutPageModel
    {
        public List<TeamMember> TeamMembers { get; set; }
        public List<CustomerReview> CustomerReviews { get; set; }
    }
}