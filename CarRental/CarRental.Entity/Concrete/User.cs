using CarRental.Core.Entity.Concrete;
using System.Collections.Generic;

namespace CarRental.Entity.Concrete
{
    public class User : CoreEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public Role Role { get; set; }
        public bool IsOnline { get; set; }
        
        public List<Comment> Comments { get; set; }
    }
    
    public enum Role { User, Admin }
}