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
						CodServicio = 4,
						CantHoras = 180,
						ValorHora = 300,
						Costo = 54000,
						Activo = true
					},
                    new Trabajo
                    {
                        Id = 4,
                        Fecha = DateTime.Now,
                        CodProyecto = 4,
                        CodServicio = 2,
                        CantHoras = 123,
                        ValorHora = 350,
                        Costo = 43050,
                        Activo = true
                    },
                    new Trabajo
                    {
                        Id = 5,
                        Fecha = DateTime.Now,
                        CodProyecto = 5,
                        CodServicio = 2,
                        CantHoras = 150,
                        ValorHora = 350,
                        Costo = 52500,
                        Activo = true
                    },
                    new Trabajo
                    {
                        Id = 6,
                        Fecha = DateTime.Now,
                        CodProyecto = 6,
                        CodServicio = 2,
                        CantHoras = 200,
                        ValorHora = 200,
                        Costo = 40000,
                        Activo = true
                    },
                    new Trabajo
                    {
                        Id = 7,
                        Fecha = DateTime.Now,
                        CodProyecto = 3,
                        CodServicio = 4,
                        CantHoras = 220,
                        ValorHora = 180,
                        Costo = 39600,
                        Activo = true

                    });
		}
	}
}

