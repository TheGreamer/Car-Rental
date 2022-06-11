namespace CarRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shipments", "ShipmentState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shipments", "ShipmentState");
        }
    }
}
