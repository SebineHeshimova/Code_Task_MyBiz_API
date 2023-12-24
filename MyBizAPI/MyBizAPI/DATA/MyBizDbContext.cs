using Microsoft.EntityFrameworkCore;
using MyBizAPI.Configurations;
using MyBizAPI.Entity;

namespace MyBizAPI.DATA
{
    public class MyBizDbContext:DbContext
    {
        public MyBizDbContext(DbContextOptions<MyBizDbContext> options) : base(options) { }
         
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
