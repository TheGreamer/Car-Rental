namespace CarRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false),
                        Article = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        UserImage = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        PositiveRateCount = c.Int(nullable: false),
                        NegativeRateCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.CarImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Year = c.String(nullable: false),
                        MonthlyPayment = c.Double(nullable: false),
                        CashIncentive = c.String(nullable: false),
                        TransferFee = c.Double(nullable: false),
                        DispositionFee = c.Double(nullable: false),
                        LeasingCompany = c.String(nullable: false),
                        LeaseEndDate = c.DateTime(nullable: false),
                        SeatingCapacity = c.Int(nullable: false),
                        GasolineType = c.String(nullable: false),
                        KilometersPerLiter = c.Double(nullable: false),
                        GearType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Review = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Answer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Body = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WebSite = c.String(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PricingPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        SearchAllListings = c.Boolean(nullable: false),
                        CreateWishlist = c.Boolean(nullable: false),
                        SeeSellerContact = c.Boolean(nullable: false),
                        FullListingInfo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Position = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        FacebookLink = c.String(nullable: false),
                        InstagramLink = c.String(nullable: false),
                        SkypeLink = c.String(nullable: false),
                        TelegramLink = c.String(nullable: false),
                        LinkedinLink = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarImages", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropIndex("dbo.CarImages", new[] { "CarId" });
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropTable("dbo.TeamMembers");
            DropTable("dbo.PricingPlans");
            DropTable("dbo.Partners");
            DropTable("dbo.Messages");
            DropTable("dbo.Faqs");
            DropTable("dbo.CustomerReviews");
            DropTable("dbo.Cars");
            DropTable("dbo.CarImages");
            DropTable("dbo.Comments");
            DropTable("dbo.Blogs");
        }
    }
}
