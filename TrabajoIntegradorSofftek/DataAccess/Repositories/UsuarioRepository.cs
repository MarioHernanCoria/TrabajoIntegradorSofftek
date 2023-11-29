using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.DataAccess.Repositories.Interfaces;
using TrabajoIntegradorSofftek.DTOs;
using TrabajoIntegradorSofftek.Entities;
using TrabajoIntegradorSofftek.DataAccess;
using TrabajoIntegradorSofftek.Helpers;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofftek.Services.Interfaces;

namespace TrabajoIntegradorSofftek.DataAccess.Repositories
{
	public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(AppDbContext context) : base(context) { }


		public override async Task<bool> Update(Usuario updateUsuario)
		{
			var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == updateUsuario.Id);
			if (usuario == null) { return false; }

			usuario.Nombre = updateUsuario.Nombre;
			usuario.Email = updateUsuario.Email;
			usuario.Clave = updateUsuario.Clave;
			usuario.Activo = updateUsuario.Activo;
			usuario.CodRol = updateUsuario.CodRol;

			_context.Usuarios.Update(usuario);
			return true;
		}

		public override async Task<bool> Delete(int id)
		{
			var usuario = await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
			if (usuario != null)
			{
				_context.Usuarios.Remove(usuario);
			}
			return true;
		}

		public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
		{
			return await _context.Usuarios.Include(x => x.Roles).SingleOrDefaultAsync(x => x.Email == dto.Email && x.Clave == PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Email));
		}

        public async Task<bool> UsuarioEx(string Email)
        {
            return await _context.Usuarios.AnyAsync(x => x.Email == Email);
        }

        public override async Task<bool> GetByEmail(string email)
        {
            var usuario = await _context.Usuarios.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (usuario != null)
            {
                return true;
            }

            return false;

        }
    }
}