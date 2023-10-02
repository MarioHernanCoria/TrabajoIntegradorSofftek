using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoIntegradorSofftek.Migrations
{
    public partial class Primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    CodProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.CodProyecto);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    CodRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.CodRol);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    CodServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.CodServicio);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    CodRol = table.Column<int>(type: "int", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_CodRol",
                        column: x => x.CodRol,
                        principalTable: "Roles",
                        principalColumn: "CodRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    CodTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodProyecto = table.Column<int>(type: "int", nullable: false),
                    CodServicio = table.Column<int>(type: "int", nullable: false),
                    CantHoras = table.Column<int>(type: "int", nullable: false),
                    ValorHora = table.Column<double>(type: "float", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.CodTrabajo);
                    table.ForeignKey(
                        name: "FK_Trabajos_Proyectos_CodProyecto",
                        column: x => x.CodProyecto,
                        principalTable: "Proyectos",
                        principalColumn: "CodProyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajos_Servicios_CodServicio",
                        column: x => x.CodServicio,
                        principalTable: "Servicios",
                        principalColumn: "CodServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "CodProyecto", "Activo", "Direccion", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Av Rivadavia 3500", 1, "EcoGas" },
                    { 2, true, "Av. Cordoba 2834", 2, "GasTech Innovate" },
                    { 3, true, "Av. Pedro Goyena 643", 3, "GasCom Connect" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "CodRol", "Activo", "Descripcion" },
                values: new object[,]
                {
                    { 1, true, "Administrador" },
                    { 2, true, "Consultor" }
                });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "CodServicio", "Descripcion", "Estado", "ValorHora" },
                values: new object[,]
                {
                    { 1, "Conversiones a Gas Natural", true, 500m },
                    { 2, "Instalacion de Medidores y Conexiones", true, 350m },
                    { 3, "Mantenimiento de Redes y Tuberias", true, 230m }
                });

            migrationBuilder.InsertData(
                table: "Trabajos",
                columns: new[] { "CodTrabajo", "Activo", "CantHoras", "CodProyecto", "CodServicio", "Costo", "Fecha", "ValorHora" },
                values: new object[,]
                {
                    { 1, true, 403, 1, 1, 120900.0, new DateTime(2023, 9, 29, 7, 15, 7, 160, DateTimeKind.Local).AddTicks(8269), 300.0 },
                    { 2, true, 245, 2, 3, 61250.0, new DateTime(2023, 9, 29, 7, 15, 7, 160, DateTimeKind.Local).AddTicks(8278), 250.0 },
                    { 3, true, 123, 3, 2, 43050.0, new DateTime(2023, 9, 29, 7, 15, 7, 160, DateTimeKind.Local).AddTicks(8279), 350.0 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "CodUsuario", "Activo", "Clave", "CodRol", "Dni", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "1234", 1, 43456342, "Mario Coria" },
                    { 2, true, "2143", 2, 12345678, "Marco Gonzales" },
                    { 3, true, "4321", 1, 87654321, "Marco Abriola" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_CodProyecto",
                table: "Trabajos",
                column: "CodProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_CodServicio",
                table: "Trabajos",
                column: "CodServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CodRol",
                table: "Usuarios",
                column: "CodRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
