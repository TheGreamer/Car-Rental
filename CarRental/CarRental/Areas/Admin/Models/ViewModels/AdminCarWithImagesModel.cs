using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Areas.Admin.Models.ViewModels
{
    public class AdminCarWithImagesModel
    {
        public Car Car { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}