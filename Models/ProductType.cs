using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coolblue_assesment.Models
{
    public class ProductType
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public bool canBeInsured { get; set; }

        public List<Product>? Products {get; set;}
    }
}