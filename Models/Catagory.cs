using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje.Models
{
    public class Catagory
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; } = "null";
    }
}