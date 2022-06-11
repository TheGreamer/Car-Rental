using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Models.ViewModels
{
    public class CarListModel
    {
        public List<Car> Cars { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}