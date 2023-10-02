﻿using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.Entities;

namespace TrabajoIntegradorSofftek.DataAccess.DatabaseSeeding
{
	public class ProyectoSeeder : IEntitySeeder
	{
		public void SeedDataBase(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Proyecto>().HasData(
					new Proyecto
					{
						Id = 1,
						Nombre = "EcoGas",
						Direccion = "Av Rivadavia 3500",
						Estado = 1,
						Activo = true

					},
					new Proyecto
					{
						Id = 2,
						Nombre = "GasTech Innovate",
						Direccion = "Av. Cordoba 2834",
						Estado = 2,
						Activo = true
					},
					new Proyecto
					{
						Id = 3,
						Nombre = "GasCom Connect",
						Direccion = "Av. Pedro Goyena 643",
						Estado = 3,
						Activo = true
					});
		}
	}
}
