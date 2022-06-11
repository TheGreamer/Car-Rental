namespace CarRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsOnline", c => c.Boolean());
            AlterColumn("dbo.Users", "Role", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "IsOnline");
        }
    }
}
