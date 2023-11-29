using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoIntegradorSofftek.Migrations
{
    public partial class seeders : Migration
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
                    ValorHora = table.Column<double>(type: "float", nullable: false)
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
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    CodRol = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    { 3, true, "Av. Pedro Goyena 643", 3, "GasCom Connect" },
                    { 4, true, "Calle del Sol 123", 2, "EcoGarden" },
                    { 5, true, "Avenida Tecnológica 789", 1, "GasSolutions" },
                    { 6, true, "Calle de la Salud 456", 4, "HealthTrack" }
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
                    { 1, "Conversiones a Gas Natural", false, 500.0 },
                    { 2, "Instalacion de Medidores y Conexiones", true, 350.0 },
                    { 3, "Mantenimiento de Redes y Tuberias", true, 230.0 },
                    { 4, "Servicio de Seguimiento", true, 300.0 },
                    { 5, "Consultoría en Seguridad", true, 200.0 },
                    { 6, "Servicio de Reparación", true, 180.0 }
                });

            migrationBuilder.InsertData(
                table: "Trabajos",
                columns: new[] { "CodTrabajo", "Activo", "CantHoras", "CodProyecto", "CodServicio", "Costo", "Fecha", "ValorHora" },
                values: new object[,]
                {
                    { 1, true, 403, 1, 1, 120900.0, new DateTime(2023, 10, 31, 13, 45, 11, 613, DateTimeKind.Local).AddTicks(5321), 300.0 },
                    { 2, true, 245, 2, 3, 61250.0, new DateTime(2023, 10, 31, 13, 45, 11, 613, DateTimeKind.Local).AddTicks(5330), 250.0 },
                    { 3, true, 180, 3, 4, 54000.0, new DateTime(2023, 10, 31, 13, 45, 11, 613, DateTimeKind.Local).AddTicks(5331), 300.0 },
                    { 4, true, 123, 4, 2, 43050.0, new DateTime(2023, 10, 31, 13, 45, 11, 613, DateTimeKind.Local).AddTicks(5332), 350.0 },
                    { 5, true, 150, 5, 2, 52500.0, new DateTime(2023, 10, 31, 13, 45, 11, 613, DateTimeKind.Local).AddTicks(5332), 350.0 },
                    { 6, true, 200, 6, 2, 40000.0, new DateTime(2023, 10, 31, 13, 45, 11, 613, DateTimeKind.Local).AddTicks(5333), 200.0 },
                    { 7, true, 220, 3, 4, 39600.0, new DateTime(2023, 10, 31, 13, 45, 11, 613, DateTimeKind.Local).AddTicks(5334), 180.0 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "CodUsuario", "Activo", "Apellido", "Clave", "CodRol", "Dni", "Edad", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Coria", "2191227b07660b208a127900f141134edcef520b5f2076f2c08884822e6cd610", 1, 43456342, 23, "mariocoria@gmail.com", "Mario" },
                    { 2, true, "Gonzales", "04e9ebfffd0597ff2a5bba0f510a2a8ba75be7863eeca58dca33463fb61eaa0d", 2, 12345678, 32, "marcogonzales@gmail.com", "Marco" },
                    { 3, true, "Abriola", "f2bb40e4308e58987c6991d243c3be39edd1da1ca0047f13fb04603feb750a80", 1, 87654321, 22, "marcoabriola@gmail.com", "Marco" },
                    { 4, true, "Correa", "5a632a97daad8e256792ac64fae021b5b1b1cfc6ca2d042cd7a8b9246342159a", 2, 26385623, 32, "mariacorrea@gmail.com", "Maria" },
                    { 5, true, "Corbalan", "aacb9ff49f127c203a95b4cab90572356dd034b7080702b4b078b9a926d30e5f", 1, 92857463, 32, "fernandocorbalan@gmail.com", "Fernando" },
                    { 6, true, "Duran", "9fd21154cf0f5affb40b1243de465b4127cd4b3379079ee9c7672bb5920ad117", 2, 25463548, 26, "brianduran@gmail.com", "Brian" }
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
