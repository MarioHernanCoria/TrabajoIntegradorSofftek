using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.DataAccess.DatabaseSeeding;
using TrabajoIntegradorSofftek.Entities;

namespace TrabajoIntegradorSofftek.DataAccess
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Proyecto> Proyectos { get; set; }
		public DbSet<Servicio> Servicios { get; set; }
		public DbSet<Trabajo> Trabajos { get; set; }
		public DbSet<Rol> Roles { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var seeders = new List<IEntitySeeder>
			{
				new UsuarioSeeder(),
				new ProyectoSeeder(),
				new ServicioSeeder(),
				new TrabajoSeeder(),
				new RolSeeder(),
			};
			foreach (var seeder in seeders)
			{
				seeder.SeedDataBase(modelBuilder);
			}
			base.OnModelCreating(modelBuilder);
		}
	}
}
