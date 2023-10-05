using Microsoft.AspNetCore.Identity;
using User_Management_WebApp.Constants;
using User_Management_WebApp.Models;

namespace User_Management_WebApp.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new ApplicationRole(Roles.SuperAdmin));
                await roleManager.CreateAsync(new ApplicationRole(Roles.Admin));
                await roleManager.CreateAsync(new ApplicationRole(Roles.Guest));
            }
        }
    }
}
