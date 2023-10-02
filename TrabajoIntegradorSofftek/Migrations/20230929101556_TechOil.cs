using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoIntegradorSofftek.Migrations
{
    public partial class TechOil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 29, 7, 15, 56, 10, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 9, 29, 7, 15, 56, 10, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2023, 9, 29, 7, 15, 56, 10, DateTimeKind.Local).AddTicks(6032));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 29, 7, 15, 7, 160, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 9, 29, 7, 15, 7, 160, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2023, 9, 29, 7, 15, 7, 160, DateTimeKind.Local).AddTicks(8279));
        }
    }
}
