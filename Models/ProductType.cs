using System.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coolblue_assesment.Models
{

    public enum ProductTypeEnum
    {
        Laptops,
        Smartphones,
        DigitalCameras,
        SlrCameras,
        MP3Players,
        WashingMachines,
    }

    public class ProductType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public bool canBeInsured { get; set; }

        public ProductTypeEnum? productTypeEnum  { get; set; }

        public ICollection<Product> Products {get; set;}
    }
}