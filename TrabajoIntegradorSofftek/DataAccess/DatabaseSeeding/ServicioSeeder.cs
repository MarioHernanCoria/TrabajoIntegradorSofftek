using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.Entities;

namespace TrabajoIntegradorSofftek.DataAccess.DatabaseSeeding
{
	public class ServicioSeeder : IEntitySeeder
	{
		public void SeedDataBase(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Servicio>().HasData(
					new Servicio
					{
						Id = 1,
						Descripcion = "Conversiones a Gas Natural",
						Estado = false,
						ValorHora = 500,
					},
					new Servicio
					{
						Id = 2,
						Descripcion = "Instalacion de Medidores y Conexiones",
						Estado = true,
						ValorHora = 350,
					},
					new Servicio
					{
						Id = 3,
						Descripcion = "Mantenimiento de Redes y Tuberias",
						Estado = true,
						ValorHora = 230,
					});
		}
	}
}
