using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            ToTable("Comments");

            Property(c => c.Date).IsRequired();
            Property(c => c.Text).IsRequired();
            Property(c => c.PositiveRateCount).IsRequired();
            Property(c => c.NegativeRateCount).IsRequired();
        }
    }
}