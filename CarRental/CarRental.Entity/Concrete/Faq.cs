using CarRental.Core.Entity.Concrete;

namespace CarRental.Entity.Concrete
{
    public class Faq : CoreEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}