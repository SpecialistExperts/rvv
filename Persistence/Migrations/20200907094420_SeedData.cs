using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Adress", "Email", "Name", "PhoneNumber", "VacationAdress", "ValidInfo", "created_at", "updated_at" },
                values: new object[] { 5, "Adres1", "Email1", "naam1", "telefoonnummer1", "Vakantieadres1", true, new DateTime(2020, 9, 7, 11, 44, 20, 677, DateTimeKind.Local).AddTicks(2320), new DateTime(2020, 9, 7, 11, 44, 20, 679, DateTimeKind.Local).AddTicks(3991) });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Adress", "Email", "Name", "PhoneNumber", "VacationAdress", "ValidInfo", "created_at", "updated_at" },
                values: new object[] { 6, "Adres2", "Email2", "naam2", "telefoonnummer2", "Vakantieadres2", true, new DateTime(2020, 9, 7, 11, 44, 20, 679, DateTimeKind.Local).AddTicks(4422), new DateTime(2020, 9, 7, 11, 44, 20, 679, DateTimeKind.Local).AddTicks(4446) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
