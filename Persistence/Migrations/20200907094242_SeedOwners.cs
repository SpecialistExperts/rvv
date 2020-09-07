using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Values",
                table: "Values");

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameTable(
                name: "Values",
                newName: "Owners");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Values");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Values",
                table: "Values",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Adress", "Email", "Name", "PhoneNumber", "VacationAdress", "ValidInfo", "created_at", "updated_at" },
                values: new object[] { 5, "Adres1", "Email1", "naam1", "telefoonnummer1", "Vakantieadres1", true, new DateTime(2020, 9, 7, 10, 58, 13, 686, DateTimeKind.Local).AddTicks(1610), new DateTime(2020, 9, 7, 10, 58, 13, 688, DateTimeKind.Local).AddTicks(3245) });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Adress", "Email", "Name", "PhoneNumber", "VacationAdress", "ValidInfo", "created_at", "updated_at" },
                values: new object[] { 6, "Adres2", "Email2", "naam2", "telefoonnummer2", "Vakantieadres2", true, new DateTime(2020, 9, 7, 10, 58, 13, 688, DateTimeKind.Local).AddTicks(3669), new DateTime(2020, 9, 7, 10, 58, 13, 688, DateTimeKind.Local).AddTicks(3691) });
        }
    }
}
