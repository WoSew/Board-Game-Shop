namespace BoardGameShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    IconFileName = c.String(),
                })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.Games",
                c => new
                {
                    GameID = c.Int(nullable: false, identity: true),
                    CategoryId = c.Int(nullable: false),
                    GameTitle = c.String(),
                    DesignerName = c.String(),
                    DateAdded = c.DateTime(nullable: false),
                    GameFileName = c.String(),
                    Description = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    IsBestseller = c.Boolean(nullable: false),
                    IsHidder = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.OrderItems",
                c => new
                {
                    OrderItemId = c.Int(nullable: false, identity: true),
                    OrderId = c.Int(nullable: false),
                    GameId = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.GameId);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    OrderId = c.Int(nullable: false, identity: true),
                    FirstName = c.String(maxLength: 150),
                    LastName = c.String(maxLength: 150),
                    Address = c.String(),
                    CodeAndCity = c.String(nullable: false, maxLength: 50),
                    PhoneNumber = c.String(),
                    Email = c.String(),
                    Comment = c.String(),
                    DateCreated = c.DateTime(nullable: false),
                    OrderState = c.Int(nullable: false),
                    TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.OrderId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "CategoryId", "dbo.Categories");
            DropIndex("dbo.OrderItems", new[] { "GameId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Games", new[] { "CategoryId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Games");
            DropTable("dbo.Categories");
        }
    }
}
