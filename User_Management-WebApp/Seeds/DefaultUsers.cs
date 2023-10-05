using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using User_Management_WebApp.Constants;
using User_Management_WebApp.Models;

namespace User_Management_WebApp.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedGustUserAsync(UserManager<ApplicationUser> userManager)
        {
            var guestUser = new ApplicationUser
            {
                Email = "guestuser@domin.com",
                UserName = "guestuser",
                EmailConfirmed = true,
                First_Name = "guestuser",
                Last_Name = "guestuser",
                DateOfBirth = DateOnly.Parse("1990-01-01"),
            };

            var user = await userManager.FindByEmailAsync(guestUser.Email);

            if(user == null)
            {
                await userManager.CreateAsync(guestUser, "P@ssword123");
                await userManager.AddToRoleAsync(guestUser, Roles.Guest);
            }

        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var adminUser = new ApplicationUser
            {
                Email = "admin@domin.com",
                UserName = "admin",
                EmailConfirmed = true,
                First_Name = "admin",
                Last_Name = "admin",
                DateOfBirth = DateOnly.Parse("1990-01-01"),
            };

            var user = await userManager.FindByEmailAsync(adminUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(adminUser, "P@ssword123");
                await userManager.AddToRolesAsync(adminUser, new List<string> { Roles.Admin, Roles.Guest });
            }


        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var guestUser = new ApplicationUser
            {
                Email = "superadmin@domin.com",
                UserName = "superadmin",
                EmailConfirmed = true,
                First_Name = "superadmin",
                Last_Name = "superadmin",
                DateOfBirth = DateOnly.Parse("1990-01-01"),
            };

            var user = await userManager.FindByEmailAsync(guestUser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(guestUser, "P@ssword123");
                await userManager.AddToRolesAsync(guestUser, new List<string> { Roles.SuperAdmin, Roles.Admin, Roles.Guest });
            }

            //seed Claims
            await roleManager.SeedClaimsForSuperAdmin();

        }

        private static async Task SeedClaimsForSuperAdmin(this RoleManager<ApplicationRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin);
            if (adminRole != null)
                await roleManager.AddPermissionClaims(adminRole, Modules.Employee.ToString());
        }

        private static async Task AddPermissionClaims(this RoleManager<ApplicationRole> roleManager, ApplicationRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermitionsList(module);

            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(x => x.Type == ClaimPermationTypes.Permations.ToString() && x.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim(ClaimPermationTypes.Permations.ToString(), permission));
            }
        }

    }
}
