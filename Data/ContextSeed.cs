using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebProje.Models;

namespace WebProje.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
{
        //Seed Default User
        var defaultUser = new ApplicationUser 
        { 
            Name = "superadmin", 
            Surname = "superadmin@gmail.com",
            EmailConfirmed = true, 
            PhoneNumberConfirmed = true 
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if(user==null)
            {
                await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
            }
                
        }
    }
    }

    public enum Roles
    {
        Admin,
        User
    }
}