using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje.Models
{
    public class cartEntry
    {
        [Key]
        public int cartEntryid { get; set; }
    
        [Required]
        public Product product { get; set; } = null;

        [Required]
        public cart cart { get; set; } = null;

        public int quantity { get; set; }
    }
}