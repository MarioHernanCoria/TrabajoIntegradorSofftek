using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.DataAccess.Repositories.Interfaces;
using TrabajoIntegradorSofftek.Entities;

namespace TrabajoIntegradorSofftek.DataAccess.Repositories
{
	public class ServicioRepository : Repository<Servicio>, IServicioRepository
	{
		public ServicioRepository(AppDbContext context) : base(context) { }


		public override async Task<bool> Update(Servicio updateServicio)
		{
			var servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.Id == updateServicio.Id);
			if (servicio == null) { return false; }

			servicio.Descripcion = updateServicio.Descripcion;
			servicio.Estado = updateServicio.Estado;
			servicio.ValorHora = updateServicio.ValorHora;

			_context.Servicios.Update(servicio);
			return true;
		}

		public override async Task<bool> Delete(int id)
		{
			var servicio = await _context.Servicios.Where(x => x.Id == id).FirstOrDefaultAsync();
			if (servicio != null)
			{
				_context.Servicios.Remove(servicio);
			}
			return true;
		}


		public virtual async Task<List<Servicio>> GetByEstado(bool estado)
		{
			return await _context.Servicios.Where(e => e.Estado == estado).ToListAsync();
		}

	}
}
