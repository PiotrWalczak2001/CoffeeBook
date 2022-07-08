using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeBook.Persistence.Migrations
{
    public partial class addTestingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Origins",
                columns: new[] { "Id", "Country", "Region" },
                values: new object[] { 1, "Brazil", "Mococa" });

            migrationBuilder.InsertData(
                table: "Roasters",
                columns: new[] { "Id", "City", "Country", "Name" },
                values: new object[] { 1, "Stockholm", "Sweden", "Johan & Nystrom" });

            migrationBuilder.InsertData(
                table: "Coffees",
                columns: new[] { "Id", "MachiningProcess", "Name", "OriginId", "RoasterId", "RoastingDate", "Type", "Variety" },
                values: new object[] { 1, 0, "Testowa Kawa", 1, 1, new DateTime(2022, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), 0, "Bourbon, Mundo Novo, Catuai" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "BrewedDate", "BrewingTime", "BrewingTypeEnum", "CoffeeId", "Description", "Name" },
                values: new object[] { 1, new DateTime(2022, 7, 3, 22, 52, 40, 138, DateTimeKind.Local).AddTicks(9213), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, "Super opis super kawy", "Testowa notka" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "BrewedDate", "BrewingTime", "BrewingTypeEnum", "CoffeeId", "Description", "Name" },
                values: new object[] { 2, new DateTime(2022, 7, 3, 22, 52, 40, 138, DateTimeKind.Local).AddTicks(9221), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Super opis super kawy2", "Testowa notka2" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "BrewedDate", "BrewingTime", "BrewingTypeEnum", "CoffeeId", "Description", "Name" },
                values: new object[] { 3, new DateTime(2022, 7, 3, 22, 52, 40, 138, DateTimeKind.Local).AddTicks(9227), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, "Super opis super kawy3", "Testowa notka3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Origins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roasters",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
