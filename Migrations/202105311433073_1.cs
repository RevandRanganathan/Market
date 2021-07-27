namespace Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Pkgd = c.DateTime(nullable: false),
                        Exp = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SellerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sellers");
            DropTable("dbo.Products");
        }
    }
}
