using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User_Management_WebApp.Data.Config;
using User_Management_WebApp.Models;

namespace User_Management_WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Employee> Employees { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder.HasDefaultSchema("dbo");

            builder.Entity<ApplicationUser>().ToTable("Users", "Identity");
            builder.Entity<ApplicationRole>().ToTable("Roles", "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Identity");
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("DATE");

            base.ConfigureConventions(builder);
        }
    }
}