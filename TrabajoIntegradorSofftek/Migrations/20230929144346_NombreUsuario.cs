using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoIntegradorSofftek.Migrations
{
    public partial class NombreUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CodUsuario",
                keyValue: 1,
                column: "Email",
                value: "mariocoria@gmail.com");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CodUsuario",
                keyValue: 2,
                column: "Email",
                value: "marcogonzales@gmail.com");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "CodUsuario",
                keyValue: 3,
                column: "Email",
                value: "marcoabriola@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

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
    }
}
