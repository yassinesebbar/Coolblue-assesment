using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coolblue_assesment.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public decimal salesPrice { get; set; }

        [Required]
        public ProductType? ProductType {get; set;}
    }
}