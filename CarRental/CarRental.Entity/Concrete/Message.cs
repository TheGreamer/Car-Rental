using CarRental.Core.Entity.Concrete;

namespace CarRental.Entity.Concrete
{
    public class Message : CoreEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}