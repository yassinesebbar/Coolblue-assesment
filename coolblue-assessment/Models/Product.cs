using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coolblue_assesment.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public decimal salesPrice { get; set; }

        [Required]
        public int productTypeId { get; set; }

        [Required]
        public ProductType ProductType {get; set;}
    }
}