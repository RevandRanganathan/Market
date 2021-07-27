namespace Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SellerProducts", "Name_ProductId", "dbo.Products");
            DropForeignKey("dbo.SellerProducts", "Pkgd_ProductId", "dbo.Products");
            DropForeignKey("dbo.SellerProducts", "Price_ProductId", "dbo.Products");
            DropForeignKey("dbo.SellerProducts", "Rating_ProductId", "dbo.Products");
            DropForeignKey("dbo.SellerProducts", "Exp_ProductId", "dbo.Products");
            DropIndex("dbo.SellerProducts", new[] { "Exp_ProductId" });
            DropIndex("dbo.SellerProducts", new[] { "Name_ProductId" });
            DropIndex("dbo.SellerProducts", new[] { "Pkgd_ProductId" });
            DropIndex("dbo.SellerProducts", new[] { "Price_ProductId" });
            DropIndex("dbo.SellerProducts", new[] { "Rating_ProductId" });
            DropColumn("dbo.SellerProducts", "ProductId");
            RenameColumn(table: "dbo.SellerProducts", name: "Exp_ProductId", newName: "ProductId");
            AlterColumn("dbo.SellerProducts", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.SellerProducts", "ProductId");
            AddForeignKey("dbo.SellerProducts", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            DropColumn("dbo.SellerProducts", "Date");
            DropColumn("dbo.SellerProducts", "IsActive");
            DropColumn("dbo.SellerProducts", "Name_ProductId");
            DropColumn("dbo.SellerProducts", "Pkgd_ProductId");
            DropColumn("dbo.SellerProducts", "Price_ProductId");
            DropColumn("dbo.SellerProducts", "Rating_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SellerProducts", "Rating_ProductId", c => c.Int());
            AddColumn("dbo.SellerProducts", "Price_ProductId", c => c.Int());
            AddColumn("dbo.SellerProducts", "Pkgd_ProductId", c => c.Int());
            AddColumn("dbo.SellerProducts", "Name_ProductId", c => c.Int());
            AddColumn("dbo.SellerProducts", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.SellerProducts", "Date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.SellerProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.SellerProducts", new[] { "ProductId" });
            AlterColumn("dbo.SellerProducts", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.SellerProducts", name: "ProductId", newName: "Exp_ProductId");
            AddColumn("dbo.SellerProducts", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.SellerProducts", "Rating_ProductId");
            CreateIndex("dbo.SellerProducts", "Price_ProductId");
            CreateIndex("dbo.SellerProducts", "Pkgd_ProductId");
            CreateIndex("dbo.SellerProducts", "Name_ProductId");
            CreateIndex("dbo.SellerProducts", "Exp_ProductId");
            AddForeignKey("dbo.SellerProducts", "Exp_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.SellerProducts", "Rating_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.SellerProducts", "Price_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.SellerProducts", "Pkgd_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.SellerProducts", "Name_ProductId", "dbo.Products", "ProductId");
        }
    }
}
