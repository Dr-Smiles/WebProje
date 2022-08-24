using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebProje.Data
{
    public class ProductContext : DbContext
    {

        public ProductContext (DbContextOptions<ProductContext> options)
            : base(options)
        {
        }
    
        public DbSet<WebProje.Models.Brand> Brand { get; set; }

        public DbSet<WebProje.Models.Product> Product { get; set; }

        public DbSet<WebProje.Models.Catagory> Catagory { get; set; }

        public DbSet<WebProje.Models.cart> cart { get; set; }

        public DbSet<WebProje.Models.cartEntry> cart_item { get; set; }
    }
}