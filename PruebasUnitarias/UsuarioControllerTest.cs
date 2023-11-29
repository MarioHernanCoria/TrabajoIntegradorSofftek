using Xunit;
using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.DataAccess;
using TrabajoIntegradorSofftek.Entities;
using TrabajoIntegradorSofftek.DataAccess.Repositories;
using System.Linq;
using TrabajoIntegradorSofftek.DataAccess.DatabaseSeeding;

namespace PruebasUnitarias
{
    public class UsuarioRepositoryTest
    {

        // Test para obtener un usuario por ID
        [Fact]
        public async Task GetByIdTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Usuario")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Database.EnsureCreated();
                context.Usuarios.Add(new Usuario
                {
                    Id = 9,
                    Nombre = "Mariana",
                    Apellido = "Vargas",
                    Edad = 26,
                    Dni = 25473545,
                    CodRol = 1,
                    Email = "marianavargas@gmail.com",
                    Clave = "7777",
                    Activo = true
                });
                context.SaveChanges();

                var repository = new Repository<Usuario>(context);

                // Act
                var result = await repository.GetById(9);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(9, result.Id);
            }
        }


        // Test para agregar un usuario
        [Fact]
        public async Task AgregarTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Usuario")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Database.EnsureCreated();
                context.Usuarios.Add(new Usuario
                {
                    Id = 8,
                    Nombre = "Mariana",
                    Apellido = "Vargas",
                    Edad = 26,
                    Dni = 25473545,
                    CodRol = 1,
                    Email = "marianavargas@gmail.com",
                    Clave = "7777",
                    Activo = true
                });
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var repository = new Repository<Usuario>(context);

                // Act
                var result = await repository.GetById(8);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Mariana", result.Nombre);
                Assert.Equal("Vargas", result.Apellido);
                Assert.Equal(26, result.Edad);

            }
        }


        // Test para actualizar los detalles de un usuario
        [Fact]
        public async Task UpdateTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Usuario")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Database.EnsureCreated();
                var usuario = new Usuario
                {
                    Id = 10,
                    Nombre = "Carlos",
                    Apellido = "Soria",
                    Edad = 29,
                    Dni = 45362536,
                    CodRol = 1,
                    Email = "carlossoria@gmail.com",
                    Clave = "9999",
                    Activo = true
                };
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var repository = new Repository<Usuario>(context);

                // Act
                var result = await repository.GetById(1);
                result.Edad = 25; // Actualizar la edad
                await repository.Update(result);
                var updatedResult = await repository.GetById(1);

                // Assert
                Assert.Equal(24, updatedResult.Edad);
            }
        }


        // Test para eliminar un usuario
        [Fact]
        public async Task DeleteTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Usuario")
                .Options;

            using (var context = new AppDbContext(options))
            {
                context.Database.EnsureCreated();
                var usuario = new Usuario
                {
                    Id = 10,
                    Nombre = "Carlos",
                    Apellido = "Soria",
                    Edad = 29,
                    Dni = 45362536,
                    CodRol = 1,
                    Email = "carlossoria@gmail.com",
                    Clave = "9999",
                    Activo = true
                };
                context.Usuarios.Add(usuario);
                context.SaveChanges();

                // Act
                var repository = new Repository<Usuario>(context);
                await repository.Delete(usuario.Id);
                var result = await repository.GetById(usuario.Id);

                // Assert
                Assert.Null(result);
            }
        }

    }
}