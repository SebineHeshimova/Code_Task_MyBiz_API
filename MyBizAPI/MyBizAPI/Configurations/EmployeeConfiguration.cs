using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBizAPI.Entity;

namespace MyBizAPI.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ImageUrl).HasMaxLength(100);
            builder.Ignore(x => x.ImageFile);
            builder.HasOne(x => x.Position).WithMany(x => x.Employees);
        }
    }
}
