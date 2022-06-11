namespace CarRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coordinates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SurName = c.String(nullable: false),
                        IdentityNumber = c.String(nullable: false),
                        DrivingLicenceNumber = c.String(nullable: false),
                        DrivingLicenceType = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedUserName = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedUserName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IotCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        PlateNumber = c.String(nullable: false),
                        VehicleType = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedUserName = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedUserName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IotCarId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        CoordinateId = c.Int(nullable: false),
                        ShipmentNumber = c.String(nullable: false),
                        Product = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedUserName = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedUserName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coordinates", t => t.CoordinateId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.IotCars", t => t.IotCarId, cascadeDelete: true)
                .Index(t => t.IotCarId)
                .Index(t => t.DriverId)
                .Index(t => t.CoordinateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipments", "IotCarId", "dbo.IotCars");
            DropForeignKey("dbo.Shipments", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Shipments", "CoordinateId", "dbo.Coordinates");
            DropIndex("dbo.Shipments", new[] { "CoordinateId" });
            DropIndex("dbo.Shipments", new[] { "DriverId" });
            DropIndex("dbo.Shipments", new[] { "IotCarId" });
            DropTable("dbo.Shipments");
            DropTable("dbo.IotCars");
            DropTable("dbo.Drivers");
            DropTable("dbo.Coordinates");
        }
    }
}
