using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoIntegradorSofftek.Migrations
{
    public partial class prueba23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorHora",
                table: "Servicios",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "CodServicio",
                keyValue: 1,
                column: "ValorHora",
                value: 500.0);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "CodServicio",
                keyValue: 2,
                column: "ValorHora",
                value: 350.0);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "CodServicio",
                keyValue: 3,
                column: "ValorHora",
                value: 230.0);

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 30, 18, 1, 30, 523, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 9, 30, 18, 1, 30, 523, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2023, 9, 30, 18, 1, 30, 523, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CodUsuario",
                keyValue: 1,
                column: "Clave",
                value: "3a492565a7a8d02b0ee918b1daf702398560373ae11aca792d34dbc5236f9219");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CodUsuario",
                keyValue: 2,
                column: "Clave",
                value: "a255a14262a960ecd991e2b92ffb31b259fe26bf510c317d1ecc27629d303c26");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CodUsuario",
                keyValue: 3,
                column: "Clave",
                value: "63399e2a0393204bf9ca560db115ab1c95b42d9a92f8f7aaa3ca29abcdfa5fc0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorHora",
                table: "Servicios",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "CodServicio",
                keyValue: 1,
                column: "ValorHora",
                value: 500m);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "CodServicio",
                keyValue: 2,
                column: "ValorHora",
                value: 350m);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "CodServicio",
                keyValue: 3,
                column: "ValorHora",
                value: 230m);

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

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CodUsuario",
                keyValue: 1,
                column: "Clave",
                value: "1234");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CodUsuario",
                keyValue: 2,
                column: "Clave",
                value: "2143");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CodUsuario",
                keyValue: 3,
                column: "Clave",
                value: "4321");
        }
    }
}
