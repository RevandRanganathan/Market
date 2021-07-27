namespace Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SellerProducts",
                c => new
                    {
                        SellerProductId = c.Int(nullable: false, identity: true),
                        SellerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SellerProductId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.SellerId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellerProducts", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.SellerProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.SellerProducts", new[] { "ProductId" });
            DropIndex("dbo.SellerProducts", new[] { "SellerId" });
            DropTable("dbo.SellerProducts");
        }
    }
}
