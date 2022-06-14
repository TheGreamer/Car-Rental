namespace CarRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CarMoves", newName: "DeviceMovements");
            DropForeignKey("dbo.Coordinates", "ShipmentId", "dbo.Shipments");
            DropIndex("dbo.Coordinates", new[] { "ShipmentId" });
            AddColumn("dbo.DeviceMovements", "IsGoing", c => c.Boolean(nullable: false));
            DropTable("dbo.Coordinates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Coordinates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipmentId = c.Int(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedUserName = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedUserName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.DeviceMovements", "IsGoing");
            CreateIndex("dbo.Coordinates", "ShipmentId");
            AddForeignKey("dbo.Coordinates", "ShipmentId", "dbo.Shipments", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.DeviceMovements", newName: "CarMoves");
        }
    }
}
