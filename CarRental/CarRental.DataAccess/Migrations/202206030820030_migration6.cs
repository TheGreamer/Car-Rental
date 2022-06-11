namespace CarRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shipments", "CoordinateId", "dbo.Coordinates");
            DropIndex("dbo.Shipments", new[] { "CoordinateId" });
            AddColumn("dbo.Coordinates", "ShipmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Coordinates", "ShipmentId");
            AddForeignKey("dbo.Coordinates", "ShipmentId", "dbo.Shipments", "Id", cascadeDelete: true);
            DropColumn("dbo.Shipments", "CoordinateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shipments", "CoordinateId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Coordinates", "ShipmentId", "dbo.Shipments");
            DropIndex("dbo.Coordinates", new[] { "ShipmentId" });
            DropColumn("dbo.Coordinates", "ShipmentId");
            CreateIndex("dbo.Shipments", "CoordinateId");
            AddForeignKey("dbo.Shipments", "CoordinateId", "dbo.Coordinates", "Id", cascadeDelete: true);
        }
    }
}
