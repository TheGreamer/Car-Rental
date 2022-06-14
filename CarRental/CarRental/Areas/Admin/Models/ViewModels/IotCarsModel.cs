using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Areas.Admin.Models.ViewModels
{
    public class IotCarsModel
    {
        public IotCar IotCar { get; set; }
        public List<Device> Devices { get; set; }
    }
}