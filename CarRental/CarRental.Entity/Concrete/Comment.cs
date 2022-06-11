using CarRental.Core.Entity.Concrete;
using System;

namespace CarRental.Entity.Concrete
{
    public class Comment : CoreEntity
    {
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int PositiveRateCount { get; set; }
        public int NegativeRateCount { get; set; }
        
        public Blog Blog { get; set; }
        public User User { get; set; }
    }
}