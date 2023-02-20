using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Web.Data
{
    public static class DbInitalizer
    {
        public static async Task InitalizerAsync(ApplicationDbContext context, IServiceProvider serviceProvider, UserManager <ApplicationUser> userManager)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] RoleNames = { "Admin", "Teacher", "Student" };
            IdentityResult roleResult;
            foreach(var roleName in RoleNames)
            {
                var roleExists = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            string Email = "admin@myweb.com";
            string Password = "Admin,./123";
            if (userManager.FindByEmailAsync(Email).Result==null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = Email;
                user.Email = Email;
                IdentityResult result = userManager.CreateAsync(user,Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
