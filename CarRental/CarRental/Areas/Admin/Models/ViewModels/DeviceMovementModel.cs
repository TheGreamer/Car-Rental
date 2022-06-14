using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Areas.Admin.Models.ViewModels
{
    public class DeviceMovementModel
    {
        public DeviceMovement DeviceMovement { get; set; }
        public List<Device> Devices { get; set; }
    }
}