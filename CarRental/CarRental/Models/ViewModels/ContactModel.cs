using CarRental.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Models.ViewModels
{
    public class ContactModel
    {
        public Message Message { get; set; }
        public List<Partner> Partners { get; set; }
    }
}