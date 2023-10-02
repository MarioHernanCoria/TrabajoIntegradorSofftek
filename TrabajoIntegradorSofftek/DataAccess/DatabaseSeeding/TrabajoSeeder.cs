using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.Entities;

namespace TrabajoIntegradorSofftek.DataAccess.DatabaseSeeding
{
	public class TrabajoSeeder : IEntitySeeder
	{
		public void SeedDataBase(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Trabajo>().HasData(
					new Trabajo
					{
						Id = 1,
						Fecha = DateTime.Now,
						CodProyecto = 1,
						CodServicio = 1,
						CantHoras = 403,
						ValorHora = 300,
						Costo = 120900,
						Activo = true
					},
					new Trabajo
					{
						Id = 2,
						Fecha = DateTime.Now,
						CodProyecto = 2,
						CodServicio = 3,
						CantHoras = 245,
						ValorHora = 250,
						Costo = 61250,
						Activo = true

					},
					new Trabajo
					{
						Id = 3,
						Fecha = DateTime.Now,
						CodProyecto = 3,
						CodServicio = 2,
						CantHoras = 123,
						ValorHora = 350,
						Costo = 43050,
						Activo = true

					});
		}
	}
}

