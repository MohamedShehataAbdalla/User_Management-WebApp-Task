using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User_Management_WebApp.Models;

namespace User_Management_WebApp.Data.Config
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Ignore(x => x.PhoneNumberConfirmed);

            builder.Property(x => x.DateOfBirth).HasColumnType("DATE");

            builder.Property(x => x.Gender).HasDefaultValue(true);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            
        }
    }
}
