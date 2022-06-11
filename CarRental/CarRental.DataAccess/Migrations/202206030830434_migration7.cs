namespace CarRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shipments", "StartPoint", c => c.String());
            AddColumn("dbo.Shipments", "EndPoint", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shipments", "EndPoint");
            DropColumn("dbo.Shipments", "StartPoint");
        }
    }
}
