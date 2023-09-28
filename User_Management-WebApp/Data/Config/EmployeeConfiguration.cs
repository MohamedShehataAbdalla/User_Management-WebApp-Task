using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User_Management_WebApp.Models;

namespace User_Management_WebApp.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.ToTable("Employees", "dbo");

            builder.Property(x => x.BirthDate).HasColumnType("DATE");
            builder.Property(x => x.HireDate).HasColumnType("DATE");

            builder.Property(x => x.Salary).HasDefaultValue(0.00);
            builder.Property(x => x.HasHealthInsurance).HasDefaultValue(false);
            builder.Property(x => x.HasPensionPlan).HasDefaultValue(false);
            builder.Property(x => x.Gender).HasDefaultValue(true);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
        }
    }
}
