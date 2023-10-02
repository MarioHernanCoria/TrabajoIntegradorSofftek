using TrabajoIntegradorSofftek.DataAccess;
using TrabajoIntegradorSofftek.DataAccess.Repositories;
using TrabajoIntegradorSofftek.Services.Interfaces;

namespace TrabajoIntegradorSofftek.Services.Implementacion
{
	public class UnitOfWorkService : IUnitOfWork
	{
		private readonly AppDbContext _context;
		public UsuarioRepository UsuarioRepository { get; set; }
		public ProyectoRepository ProyectoRepository { get; set; }
		public ServicioRepository ServicioRepository { get; set; }
		public TrabajoRepository TrabajoRepository { get; set; }
		public RolRepository RolRepository { get; }

		public UnitOfWorkService(AppDbContext context)
		{
			_context = context;
			UsuarioRepository = new UsuarioRepository(_context);
			ProyectoRepository = new ProyectoRepository(_context);
			ServicioRepository = new ServicioRepository(_context);
			TrabajoRepository = new TrabajoRepository(_context);
			RolRepository = new RolRepository(_context);
		}

		public Task<int> Complete()
		{
			return _context.SaveChangesAsync();
		}
	}
}
