
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
                if (customer == null)
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

                return customer;
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
            app.MapGet("/services", (CompanyAPIDbContext context) =>
            {
                var services = context.Services.ToList();

                return services;
            });


            // Lägga till nya tjänster.
            app.MapPost("/services", (Service service, CompanyAPIDbContext context) =>
            {
                context.Services.Add(service);
                context.SaveChanges();

                return service;
            });

            // Uppdatera information om en tjänst.
            app.MapPut("/services/{id}", (int id, Service updatedService, CompanyAPIDbContext context) =>
            {
                var service = context.Services.FirstOrDefault(s => s.Id == id);
                if(service == null)
                {
                    return null;
                }

                service = updatedService;
                context.SaveChanges();

                return service;
            });

            // Ta bort en tjänst.
            app.MapDelete("/services{id}", (int id, CompanyAPIDbContext context) =>
            {
                var service = context.Services.FirstOrDefault(s => s.Id == id);
                if(service == null)
                {
                    return null;
                }

                context.Services.Remove(service);
                context.SaveChanges();
                return "Service removed";
            });

            app.Run();
        }
    }
}
