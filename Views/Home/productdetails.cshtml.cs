using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProje.Data;
using WebProje.Models;

namespace WebProje.Views.Home
{
    public class ProductModel : PageModel
    {
        private readonly ProductContext _context;
        public ProductModel(ProductContext context)
        {
            _context = context;
        }

        public async Task OnGet(int id)
        {
            Product prd = await _context.Product.FindAsync(id);
            ViewData["Product"] = prd;
        }

        public void OnPost(int id)
        {

        }
    }
}