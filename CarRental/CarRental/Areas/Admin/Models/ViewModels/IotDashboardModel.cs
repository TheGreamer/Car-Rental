using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Areas.Admin.Models.ViewModels
{
    public class IotDashboardModel
    {
        public int PageCount { get; set; }
        public int CarCount { get; set; }
        public int BlogCount { get; set; }
        public int CustomerReviewCount { get; set; }
        public int FaqCount { get; set; }
        public int MessageCount { get; set; }
        public int PartnerCount { get; set; }
        public int PricingPlanCount { get; set; }
        public int TeamMemberCount { get; set; }
        public int ActiveShipmentCount { get; set; }
        public int CompletedShipmentCount { get; set; }
        public int WaitingShipmentCount { get; set; }
        public int PreparingShipmentCount { get; set; }
        public int IotCarCount { get; set; }
        public int DriverCount { get; set; }
        public List<Shipment> Shipments { get; set; }
    }
}