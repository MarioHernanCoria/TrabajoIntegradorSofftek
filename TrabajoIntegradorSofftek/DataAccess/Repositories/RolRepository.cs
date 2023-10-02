using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.DataAccess.Repositories.Interfaces;
using TrabajoIntegradorSofftek.Entities;

namespace TrabajoIntegradorSofftek.DataAccess.Repositories
{
	public class RolRepository : Repository<Rol>, IRolRepository
	{
		public RolRepository(AppDbContext context) : base(context) { }

		public override async Task<bool> Update(Rol updateRol)
		{
			var rol = await _context.Roles.FirstOrDefaultAsync(x => x.Id == updateRol.Id);
			if (rol == null) { return false; }

			rol.Descripcion = updateRol.Descripcion;
			rol.Activo = updateRol.Activo;

			_context.Roles.Update(rol);
			return true;
		}

		public override async Task<bool> Delete(int id)
		{
			var rol = await _context.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
			if (rol != null)
			{
				_context.Roles.Remove(rol);
			}
			return true;
		}

	}
}
