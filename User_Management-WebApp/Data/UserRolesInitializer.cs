using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Net.Mail;
using User_Management_WebApp.Models;

namespace User_Management_WebApp.Data
{
    public static class UserRolesInitializer
    {
        public static async Task InitializerAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            // Add Roles
            string[] roleNames = { "Admin", "User" };

            foreach (var role in roleNames)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    ApplicationRole applicationRole = new()
                    {
                        Name = role,
                    };
                    await roleManager.CreateAsync(applicationRole);
                }
            }

            // Add User
            var email = "admin@domin.com";
            var password = "Admin123!";

            string dateStr = "11/11/1111";
            DateTime dateTime = DateTime.ParseExact(dateStr, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            if (userManager.FindByEmailAsync(email).Result == null)
            {
                ApplicationUser user = new()
                {
                    Email = email,
                    UserName = new MailAddress(email).User,
                    First_Name = "Admin",
                    Last_Name = "Admin",
                    EmailConfirmed = true,
                    DateOfBirth = DateOnly.FromDateTime(dateTime),
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    // Add User Roles
                    await userManager.AddToRolesAsync(user, roleNames);

                }
            }

        }
    }
}
