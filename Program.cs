
using Microsoft.EntityFrameworkCore;
using ÖvningMinimalAPIOchEF.Data;
using ÖvningMinimalAPIOchEF.Models;

namespace ÖvningMinimalAPIOchEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<CompanyAPIDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //Se en lista över alla kunder.
            app.MapGet("/customers", (CompanyAPIDbContext context) =>
            {
                var customers = context.Customers.ToList();
                return customers;
            });

            // Lägga till nya kunder.
            app.MapPost("/customers", (Customer customer, CompanyAPIDbContext context) =>
            {
                if (customer is null)
                {
                    return Results.BadRequest("Customer data saknas.");
                }

                context.Customers.Add(customer);
                context.SaveChanges();

                return Results.Created($"/customers/{customer.Id}", customer); ;
            });

            // Uppdatera information om en kund.
            app.MapPut("/customers/{id}", (int id, Customer updatedCustomer, CompanyAPIDbContext context) =>
            {
                var customer = context.Customers.FirstOrDefault(c => c.Id == id);
                if (customer == null)
                {
                    return null;
                }

                customer = updatedCustomer;
                context.SaveChanges();

                return updatedCustomer;
            });

            // Ta bort en kund.
            app.MapDelete("/customers/{id}", (int id, CompanyAPIDbContext context) =>
            {
                var customer = context.Customers.FirstOrDefault(c => c.Id == id);
                if (customer == null)
                {
                    return null;
                }

                context.Customers.Remove(customer);
                context.SaveChanges();

                return "Customer deleted";

            });


            // Se en lista över alla tjänster.


            // Lägga till nya tjänster.


            // Uppdatera information om en tjänst.


            // Ta bort en tjänst.


            app.Run();
        }
    }
}
