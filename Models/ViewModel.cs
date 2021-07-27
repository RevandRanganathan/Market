using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class ViewModel
    {
       
            

        public int SellerProductId { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
            
         public DateTime Pkgd { get; set; }
           
         public DateTime Exp { get; set; }
            
         public int Rating { get; set; }
        }
    }
