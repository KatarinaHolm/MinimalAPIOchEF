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

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                { 
                    Id = 1, 
                    Name = "Katarina", 
                    Email = "katarina@gmail.com", 
                    PhoneNr = "076-479 35 64" 
                },
                new Customer 
                { 
                    Id = 2, 
                    Name = "Pelle", 
                    Email = "pelle@qlok.com", 
                    PhoneNr = "070-756 49 61"
                }
                );

            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    Name = "Kaffekrisjour",
                    Description = "Akut utryckning när kaffemaskinen strejkar. Inkluderar felsökning, pep talk och nödlösning med snabbkaffe.",
                    Price = 499.00m
                },

                new Service
                {
                    Id = 2,
                    Name = "PowerPoint-räddning",
                    Description = "Vi förvandlar din röriga presentation till något som nästan ser proffsigt ut. Färger, ikoner och mindre Comic Sans.",
                    Price = 1299.00m
                },

                new Service
                {
                    Id = 3, 
                    Name = "IT-support",
                    Description = "Personlig support där vi ställer exakt samma frågor som alla andra – men med bättre tonläge.",
                    Price = 299.00m
                }
                );
        }
        

    }
}
