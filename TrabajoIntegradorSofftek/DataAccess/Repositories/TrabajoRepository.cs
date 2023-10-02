using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.DataAccess.Repositories.Interfaces;
using TrabajoIntegradorSofftek.Entities;

namespace TrabajoIntegradorSofftek.DataAccess.Repositories
{
	public class TrabajoRepository : Repository<Trabajo>, ITrabajoRepository
	{
		public TrabajoRepository(AppDbContext context) : base(context) { }


		public override async Task<bool> Update(Trabajo updateTrabajo)
		{
			var trabajo = await _context.Trabajos.FirstOrDefaultAsync(x => x.Id == updateTrabajo.Id);
			if (trabajo == null) { return false; }

			trabajo.Fecha = updateTrabajo.Fecha;
			trabajo.CodProyecto = updateTrabajo.CodProyecto;
			trabajo.CodServicio = updateTrabajo.CodServicio;
			trabajo.CantHoras = updateTrabajo.CantHoras;
			trabajo.Costo = updateTrabajo.Costo;
			trabajo.Activo = updateTrabajo.Activo;

			_context.Trabajos.Update(trabajo);
			return true;
		}

		public override async Task<bool> Delete(int id)
		{
			var Trabajo = await _context.Trabajos.Where(x => x.Id == id).FirstOrDefaultAsync();
			if (Trabajo != null)
			{
				_context.Trabajos.Remove(Trabajo);
			}
			return true;
		}
	}
}
