﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrabajoIntegradorSofftek.DataAccess;

#nullable disable

namespace TrabajoIntegradorSofftek.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230930210130_prueba23")]
    partial class prueba23
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrabajoIntegradorSofftek.Entities.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodProyecto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("Activo");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Direccion");

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Proyectos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Direccion = "Av Rivadavia 3500",
                            Estado = 1,
                            Nombre = "EcoGas"
                        },
                        new
                        {
                            Id = 2,
                            Activo = true,
                            Direccion = "Av. Cordoba 2834",
                            Estado = 2,
                            Nombre = "GasTech Innovate"
                        },
                        new
                        {
                            Id = 3,
                            Activo = true,
                            Direccion = "Av. Pedro Goyena 643",
                            Estado = 3,
                            Nombre = "GasCom Connect"
                        });
                });

            modelBuilder.Entity("TrabajoIntegradorSofftek.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodRol");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("Activo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Descripcion = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Activo = true,
                            Descripcion = "Consultor"
                        });
                });

            modelBuilder.Entity("TrabajoIntegradorSofftek.Entities.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodServicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descripcion");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("Estado");

                    b.Property<double>("ValorHora")
                        .HasColumnType("float")
                        .HasColumnName("ValorHora");

                    b.HasKey("Id");

                    b.ToTable("Servicios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Conversiones a Gas Natural",
                            Estado = false,
                            ValorHora = 500.0
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Instalacion de Medidores y Conexiones",
                            Estado = true,
                            ValorHora = 350.0
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Mantenimiento de Redes y Tuberias",
                            Estado = true,
                            ValorHora = 230.0
                        });
                });

            modelBuilder.Entity("TrabajoIntegradorSofftek.Entities.Trabajo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodTrabajo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("Activo");

                    b.Property<int>("CantHoras")
                        .HasColumnType("int")
                        .HasColumnName("CantHoras");

                    b.Property<int>("CodProyecto")
                        .HasColumnType("int")
                        .HasColumnName("CodProyecto");

                    b.Property<int>("CodServicio")
                        .HasColumnType("int")
                        .HasColumnName("CodServicio");

                    b.Property<double>("Costo")
                        .HasColumnType("float")
                        .HasColumnName("Costo");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha");

                    b.Property<double>("ValorHora")
                        .HasColumnType("float")
                        .HasColumnName("ValorHora");

                    b.HasKey("Id");

                    b.HasIndex("CodProyecto");

                    b.HasIndex("CodServicio");

                    b.ToTable("Trabajos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            CantHoras = 403,
                            CodProyecto = 1,
                            CodServicio = 1,
                            Costo = 120900.0,
                            Fecha = new DateTime(2023, 9, 30, 18, 1, 30, 523, DateTimeKind.Local).AddTicks(7982),
                            ValorHora = 300.0
                        },
                        new
                        {
                            Id = 2,
                            Activo = true,
                            CantHoras = 245,
                            CodProyecto = 2,
                            CodServicio = 3,
                            Costo = 61250.0,
                            Fecha = new DateTime(2023, 9, 30, 18, 1, 30, 523, DateTimeKind.Local).AddTicks(7992),
                            ValorHora = 250.0
                        },
                        new
                        {
                            Id = 3,
                            Activo = true,
                            CantHoras = 123,
                            CodProyecto = 3,
                            CodServicio = 2,
                            Costo = 43050.0,
                            Fecha = new DateTime(2023, 9, 30, 18, 1, 30, 523, DateTimeKind.Local).AddTicks(7993),
                            ValorHora = 350.0
                        });
                });

            modelBuilder.Entity("TrabajoIntegradorSofftek.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CodUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("Activo");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Clave");

                    b.Property<int>("CodRol")
                        .HasColumnType("int")
                        .HasColumnName("CodRol");

                    b.Property<int>("Dni")
                        .HasColumnType("int")
                        .HasColumnName("Dni");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("CodRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Clave = "3a492565a7a8d02b0ee918b1daf702398560373ae11aca792d34dbc5236f9219",
                            CodRol = 1,
                            Dni = 43456342,
                            Email = "mariocoria@gmail.com",
                            Nombre = "Mario Coria"
                        },
                        new
                        {
                            Id = 2,
                            Activo = true,
                            Clave = "a255a14262a960ecd991e2b92ffb31b259fe26bf510c317d1ecc27629d303c26",
                            CodRol = 2,
                            Dni = 12345678,
                            Email = "marcogonzales@gmail.com",
                            Nombre = "Marco Gonzales"
                        },
                        new
                        {
                            Id = 3,
                            Activo = true,
                            Clave = "63399e2a0393204bf9ca560db115ab1c95b42d9a92f8f7aaa3ca29abcdfa5fc0",
                            CodRol = 1,
                            Dni = 87654321,
                            Email = "marcoabriola@gmail.com",
                            Nombre = "Marco Abriola"
                        });
                });

            modelBuilder.Entity("TrabajoIntegradorSofftek.Entities.Trabajo", b =>
                {
                    b.HasOne("TrabajoIntegradorSofftek.Entities.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("CodProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoIntegradorSofftek.Entities.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("CodServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("TrabajoIntegradorSofftek.Entities.Usuario", b =>
                {
                    b.HasOne("TrabajoIntegradorSofftek.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("CodRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
