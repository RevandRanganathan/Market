using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime Pkgd { get; set; }
        [Required]
        public DateTime Exp { get; set; }
        [Required]
        [Range(0,5)]
        public int Rating { get; set; }
    }
}