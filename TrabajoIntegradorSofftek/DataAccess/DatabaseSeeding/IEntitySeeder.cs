using Microsoft.EntityFrameworkCore;

namespace TrabajoIntegradorSofftek.DataAccess.DatabaseSeeding
{
	public interface IEntitySeeder
	{
		void SeedDataBase(ModelBuilder modelBuilder);
	}
}
