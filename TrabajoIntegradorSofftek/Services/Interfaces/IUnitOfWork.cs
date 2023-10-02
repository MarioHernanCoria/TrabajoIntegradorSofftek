using TrabajoIntegradorSofftek.DataAccess.Repositories;

namespace TrabajoIntegradorSofftek.Services.Interfaces
{
    public interface IUnitOfWork
    {
		public ProyectoRepository ProyectoRepository { get; }
		public ServicioRepository ServicioRepository { get; }
		public TrabajoRepository TrabajoRepository { get; }
		public UsuarioRepository UsuarioRepository { get; }
		public RolRepository RolRepository { get; }
		Task<int> Complete();
	}
}
