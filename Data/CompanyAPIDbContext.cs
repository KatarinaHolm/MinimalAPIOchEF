using Microsoft.EntityFrameworkCore;
using ÖvningMinimalAPIOchEF.Models;

namespace ÖvningMinimalAPIOchEF.Data
{
    public class CompanyAPIDbContext : DbContext
    {
        public CompanyAPIDbContext(DbContextOptions<CompanyAPIDbContext> options) : base(options)
        {
            
        }

        public DbSet<Service> Services { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasPrecision(10, 2);
        }
        

    }
}
