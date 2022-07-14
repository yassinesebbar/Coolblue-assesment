using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coolblue_assesment.Dtos
{
    public class ProductReadDto
    {
        [Key]
        private int id { get; set; }

        [Required]
        private string name { get; set; }

        [Required]
        private decimal salesPrice { get; set; }

        [Required]
        private int ProductTypeId {get; set;}
    }
}