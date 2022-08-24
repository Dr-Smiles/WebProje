using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebProje.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String Name { get; set; } = "";

        public String Surname { get; set; } = "";
    }
}