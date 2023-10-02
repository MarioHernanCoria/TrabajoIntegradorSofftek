using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoIntegradorSofftek.Migrations
{
    public partial class rol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 30, 14, 54, 45, 307, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 9, 30, 14, 54, 45, 307, DateTimeKind.Local).AddTicks(3967));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2023, 9, 30, 14, 54, 45, 307, DateTimeKind.Local).AddTicks(3968));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 30, 14, 12, 3, 281, DateTimeKind.Local).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 9, 30, 14, 12, 3, 281, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2023, 9, 30, 14, 12, 3, 281, DateTimeKind.Local).AddTicks(1025));
        }
    }
}
