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
					Nombre = "Mario Coria",
					Dni = 43456342,
					CodRol = 1,
					Email = "mariocoria@gmail.com",
					Clave = PasswordEncryptHelper.EncryptPassword("1234", "mariocoria@gmail.com"),
					Activo = true

				},

				new Usuario
				{
					Id = 2,
					Nombre = "Marco Gonzales",
					Dni = 12345678,
					CodRol = 2,
					Email = "marcogonzales@gmail.com",
					Clave = PasswordEncryptHelper.EncryptPassword("2143", "marcogonzales@gmail.com"),
					Activo = true

				},

				new Usuario
				{
					Id = 3,
					Nombre = "Marco Abriola",
					Dni = 87654321,
					CodRol = 1,
					Email = "marcoabriola@gmail.com",
					Clave = PasswordEncryptHelper.EncryptPassword("4321", "marcoabriola@gmail.com"),
					Activo = true

				});		
		}
	}
}
