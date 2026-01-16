using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ÖvningMinimalAPIOchEF.Migrations
{
    /// <inheritdoc />
    public partial class SeedServicesAndCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "PhoneNr" },
                values: new object[,]
                {
                    { 1, "katarina@gmail.com", "Katarina", "076-479 35 64" },
                    { 2, "pelle@qlok.com", "Pelle", "070-756 49 61" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Akut utryckning när kaffemaskinen strejkar. Inkluderar felsökning, pep talk och nödlösning med snabbkaffe.", "Kaffekrisjour", 499.00m },
                    { 2, "Vi förvandlar din röriga presentation till något som nästan ser proffsigt ut. Färger, ikoner och mindre Comic Sans.", "PowerPoint-räddning", 1299.00m },
                    { 3, "Personlig support där vi ställer exakt samma frågor som alla andra – men med bättre tonläge.", "IT-support", 299.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
