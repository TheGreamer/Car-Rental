using CarRental.Core.Entity.Concrete;
using System;

namespace CarRental.Entity.Concrete
{
    public class DeviceMovement : CoreEntity
    {
        public int DeviceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CurrentDate { get; set; }
        public bool IsGoing { get; set; }

        public Device Device { get; set; }
    }
}