using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using User_Management_WebApp.Models;

namespace User_Management_WebApp.Data
{
    public static class WebHostExtensions
    {
        public static async void RunWithSeedData(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerProvider>();
            var logger = loggerFactory.CreateLogger("app");

            try
            {
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

                await Seeds.DefaultRoles.SeedAsync(roleManager);
                await Seeds.DefaultUsers.SeedGustUserAsync(userManager);
                await Seeds.DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);

                logger.LogInformation("Data Seeded");
                logger.LogInformation("Application Started");
            }
            catch (Exception ex)
            {
                    
                logger.LogError(ex, "An error occurred while seeding data");
            }
            
        }
    }
}
