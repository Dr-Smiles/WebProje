using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; } = "null";

        [Required]
        public bool availability { get; set; } = false;

        [Required]
        public bool sale { get; set; } = false;

        [ForeignKey("Brand")]
        public Brand? brand { get; set; }

        [ForeignKey("Catagory")]
        public Catagory? catagory { get; set; }

        public string description { get; set; } = "null";

        [Required]
        public double price { get; set; } = 0;

        public string image { get; set; } = "null";
    }
}