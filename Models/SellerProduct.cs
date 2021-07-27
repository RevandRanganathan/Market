using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class SellerProduct
    {
       
        public int SellerProductId { get; set; }
        public int SellerId { get; set; }
        public int ProductId { get; set; }

       

        public virtual Seller Seller { get; set; }
        public virtual Product Product { get; set; }







    }
}