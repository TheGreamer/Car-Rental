using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Areas.Admin.Models.ViewModels
{
    public class AdminCarListModel
    {
        public List<Car> Cars { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}