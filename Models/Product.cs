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
        private int id { get; set; }

        [Required]
        private string name { get; set; }

        [Required]
        private decimal salesPrice { get; set; }

        [Required]
        public ProductType ProductType {get; set;}
    }
}