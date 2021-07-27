using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class Seller
    {
        [Key]
        public int SellerId  { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }
    }
}