using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.Entities;
using TrabajoIntegradorSofftek.Helpers;

namespace TrabajoIntegradorSofftek.DataAccess.DatabaseSeeding
{
	public class UsuarioSeeder : IEntitySeeder
	{
		public void SeedDataBase(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Usuario>().HasData(
				new Usuario
				{
					Id = 1,
					Nombre = "Mario",
                    Apellido = "Coria",
                    Edad = 23,
                    Dni = 43456342,
					CodRol = 1,
					Email = "mariocoria@gmail.com",
					Clave = PasswordEncryptHelper.EncryptPassword("1111", "mariocoria@gmail.com"),
					Activo = true

				},

				new Usuario
				{
					Id = 2,
					Nombre = "Marco",
                    Apellido = "Gonzales",
                    Edad = 32,
                    Dni = 12345678,
					CodRol = 2,
					Email = "marcogonzales@gmail.com",
					Clave = PasswordEncryptHelper.EncryptPassword("2222", "marcogonzales@gmail.com"),
					Activo = true

				},

				new Usuario
				{
					Id = 3,
					Nombre = "Marco",
                    Apellido = "Abriola",
                    Edad = 22,
                    Dni = 87654321,
					CodRol = 1,
					Email = "marcoabriola@gmail.com",
					Clave = PasswordEncryptHelper.EncryptPassword("3333", "marcoabriola@gmail.com"),
					Activo = true

				},

                new Usuario
                {
                    Id = 4,
                    Nombre = "Maria",
					Apellido = "Correa",
					Edad = 32,
                    Dni = 26385623,
                    CodRol = 2,
                    Email = "mariacorrea@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("4444", "mariacorrea@gmail.com"),
                    Activo = true

                },


                new Usuario
                {
                    Id = 5,
                    Nombre = "Fernando",
                    Apellido = "Corbalan",
                    Edad = 32,
                    Dni = 92857463,
                    CodRol = 1,
                    Email = "fernandocorbalan@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("5555", "fernandocorbalan@gmail.com"),
                    Activo = true

                },

                new Usuario
                {
					Id = 6,
                    Nombre = "Brian",
                    Apellido = "Duran",
                    Edad = 26,
                    Dni = 25463548,
                    CodRol = 2,
                    Email = "brianduran@gmail.com",
                    Clave = PasswordEncryptHelper.EncryptPassword("6666", "brianduran@gmail.com"),
                    Activo = true

                });		
		}
	}
}
