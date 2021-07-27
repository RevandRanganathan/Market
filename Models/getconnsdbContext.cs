using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class getconnsdbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerProduct> SellerProducts { get; set; }
    }
}