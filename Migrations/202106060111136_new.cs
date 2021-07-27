namespace Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SellerProducts", "SellerId");
            CreateIndex("dbo.SellerProducts", "ProductId");
            AddForeignKey("dbo.SellerProducts", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.SellerProducts", "SellerId", "dbo.Sellers", "SellerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellerProducts", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.SellerProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.SellerProducts", new[] { "ProductId" });
            DropIndex("dbo.SellerProducts", new[] { "SellerId" });
        }
    }
}
