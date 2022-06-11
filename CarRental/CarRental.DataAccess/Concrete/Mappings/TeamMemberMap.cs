using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class TeamMemberMap : EntityTypeConfiguration<TeamMember>
    {
        public TeamMemberMap()
        {
            ToTable("TeamMembers");

            Property(t => t.Name).IsRequired();
            Property(t => t.Position).IsRequired();
            Property(t => t.Image).IsRequired();
            Property(t => t.FacebookLink).IsRequired();
            Property(t => t.InstagramLink).IsRequired();
            Property(t => t.SkypeLink).IsRequired();
            Property(t => t.TelegramLink).IsRequired();
            Property(t => t.LinkedinLink).IsRequired();
        }
    }
}