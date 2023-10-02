using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.DataAccess.Repositories.Interfaces;
using TrabajoIntegradorSofftek.Entities;

namespace TrabajoIntegradorSofftek.DataAccess.Repositories
{
	public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
	{

		public ProyectoRepository(AppDbContext context) : base(context) { }

		public override async Task<bool> Update(Proyecto updateProyecto)
		{
			var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.Id == updateProyecto.Id);
			if (proyecto == null) { return false; }
			proyecto.Nombre = updateProyecto.Nombre;
			proyecto.Direccion = updateProyecto.Direccion;
			proyecto.Estado = updateProyecto.Estado;
			proyecto.Activo = updateProyecto.Activo;

			_context.Proyectos.Update(proyecto);
			return true;
		}
		public override async Task<bool> Delete(int id)
		{
			var proyecto = await _context.Proyectos.Where(x => x.Id == id).FirstOrDefaultAsync();
			if (proyecto != null)
			{
				_context.Proyectos.Remove(proyecto);
			}
			return true;
		}
		public virtual async Task<List<Proyecto>> GetByEstado(int estado)
		{
			return await _context.Proyectos.Where(e => e.Estado == estado).ToListAsync();
		}

	}
}
