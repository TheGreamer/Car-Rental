using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Models.ViewModels
{
    public class PricingPageModel
    {
        public List<PricingPlan> PricingPlans { get; set; }
        public List<Partner> Partners { get; set; }
    }
}