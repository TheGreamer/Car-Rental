namespace CarRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Image", c => c.String());
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Comments", "UserName");
            DropColumn("dbo.Comments", "UserImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserImage", c => c.String(nullable: false));
            AddColumn("dbo.Comments", "UserName", c => c.String(nullable: false));
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropColumn("dbo.Users", "Image");
            DropColumn("dbo.Comments", "UserId");
        }
    }
}
