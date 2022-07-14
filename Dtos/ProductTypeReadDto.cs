using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coolblue_assesment.Dtos
{
    public class ProductTypeReadDto
     {
        [Key]
        private int id { get; set; }
        [Required]
        private string name { get; set; }
        [Required]
        private bool canBeInsured { get; set; }
    }
}