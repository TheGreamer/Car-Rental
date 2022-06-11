using CarRental.Core.Entity.Concrete;
using System;
using System.Collections.Generic;

namespace CarRental.Entity.Concrete
{
    public class Car : CoreEntity
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public double MonthlyPayment { get; set; }
        public string CashIncentive { get; set; }
        public double TransferFee { get; set; }
        public double DispositionFee { get; set; }
        public string LeasingCompany { get; set; }
        public DateTime LeaseEndDate { get; set; }
        public int SeatingCapacity { get; set; }
        public string GasolineType { get; set; }
        public double KilometersPerLiter { get; set; }
        public string GearType { get; set; }

        public List<CarImage> Images { get; set; }
    }
}