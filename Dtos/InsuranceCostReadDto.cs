using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coolblue_assesment.Dtos
{
    public class InsuranceCostReadDto
    {
        [Key]
        public int productId { get; set; }

        [Required]
        public string productName  {get; set;}

        [Required]
        public decimal salesPrice {get; set;}

        [Required]
        public bool canBeInsured {get; set;}

        [Required]
        public decimal InsuranceCost {get; set;}   
    }
}