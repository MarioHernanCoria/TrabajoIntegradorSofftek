using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.Entities;

namespace TrabajoIntegradorSofftek.DataAccess.DatabaseSeeding
{
	public class RolSeeder : IEntitySeeder
	{
		public void SeedDataBase(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Rol>().HasData(
				new Rol
				{
					Id = 1,
					Descripcion = "Administrador",
					Activo = true,
				},
				new Rol
				{
					Id = 2,
					Descripcion = "Consultor",
					Activo = true,
				});
		}
	}
}
