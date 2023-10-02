using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoIntegradorSofftek.Migrations
{
    public partial class MaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Clave",
                table: "Usuarios",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "CodServicio",
                keyValue: 1,
                column: "Estado",
                value: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Clave",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "CodServicio",
                keyValue: 1,
                column: "Estado",
                value: true);

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2023, 9, 29, 11, 43, 46, 529, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2023, 9, 29, 11, 43, 46, 529, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "CodTrabajo",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2023, 9, 29, 11, 43, 46, 529, DateTimeKind.Local).AddTicks(7843));
        }
    }
}
