using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            Property(u => u.Name).IsRequired().HasMaxLength(20);
            Property(u => u.Surname).IsRequired().HasMaxLength(20);
            Property(u => u.UserName).IsRequired().HasMaxLength(30);
            Property(u => u.Email).IsRequired().HasMaxLength(255);
            Property(u => u.Password).IsRequired().HasMaxLength(24);
            Property(u => u.Image).IsOptional();
            Property(u => u.Role).IsOptional();
            Property(u => u.IsOnline).IsOptional();
        }
    }
}