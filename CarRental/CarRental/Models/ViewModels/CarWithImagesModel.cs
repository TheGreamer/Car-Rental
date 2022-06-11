using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Models.ViewModels
{
    public class CarWithImagesModel
    {
        public Car Car { get; set; }
        public List<CarImage> CarImages { get; set; }
        public List<Car> SimiliarCars { get; set; }
        public List<CarImage> SimiliarCarImages { get; set; }
    }
}