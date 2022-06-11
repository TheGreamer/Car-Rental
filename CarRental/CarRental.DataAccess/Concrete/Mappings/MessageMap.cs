using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            ToTable("Messages");

            Property(m => m.Name).IsRequired();
            Property(m => m.Email).IsRequired();
            Property(m => m.Subject).IsRequired();
            Property(m => m.Body).IsRequired();
        }
    }
}