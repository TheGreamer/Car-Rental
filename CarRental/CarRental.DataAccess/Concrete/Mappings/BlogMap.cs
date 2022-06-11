using CarRental.Entity.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataAccess.Concrete.Mappings
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            ToTable("Blogs");

            Property(b => b.Image).IsRequired();
            Property(b => b.Category).IsRequired();
            Property(b => b.PostDate).IsRequired();
            Property(b => b.Title).IsRequired();
            Property(b => b.Article).IsRequired();
        }
    }
}