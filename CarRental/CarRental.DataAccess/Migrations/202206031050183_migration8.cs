namespace CarRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SerialNumber = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(),
                        CreatedUserName = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(),
                        ModifiedUserName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Devices");
        }
    }
}
