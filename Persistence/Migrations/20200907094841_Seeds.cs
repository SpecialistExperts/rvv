using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2020, 9, 7, 11, 48, 41, 373, DateTimeKind.Local).AddTicks(2440), new DateTime(2020, 9, 7, 11, 48, 41, 375, DateTimeKind.Local).AddTicks(4379) });

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2020, 9, 7, 11, 48, 41, 375, DateTimeKind.Local).AddTicks(4814), new DateTime(2020, 9, 7, 11, 48, 41, 375, DateTimeKind.Local).AddTicks(4837) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Values",
                table: "Values");

            migrationBuilder.RenameTable(
                name: "Values",
                newName: "Owners");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2020, 9, 7, 11, 44, 20, 677, DateTimeKind.Local).AddTicks(2320), new DateTime(2020, 9, 7, 11, 44, 20, 679, DateTimeKind.Local).AddTicks(3991) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2020, 9, 7, 11, 44, 20, 679, DateTimeKind.Local).AddTicks(4422), new DateTime(2020, 9, 7, 11, 44, 20, 679, DateTimeKind.Local).AddTicks(4446) });
        }
    }
}
