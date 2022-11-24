using Microsoft.EntityFrameworkCore;
using TestApi.Database.Entities;
using TestApi.Database.Mapping;

namespace TestApi.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<OrderEty> Orders { get; set; }
        public DbSet<CustomerEty> Customers { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
        }
    }
}
