using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofftek.DTOs;
using TrabajoIntegradorSofftek.Entities;
using TrabajoIntegradorSofftek.Infrastructure;
using TrabajoIntegradorSofftek.Migrations;
using TrabajoIntegradorSofftek.Services.Interfaces;

namespace TrabajoIntegradorSofftek.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]

	public class RolController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		public RolController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		///  Devuelve todos los Roles
		/// </summary>
		/// <returns>retorna un statusCode 200 todos los Roles</returns>


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var Roles = await _unitOfWork.RolRepository.GetAll();

			return ResponseFactory.CreateSuccessResponse(200, Roles);
		}

		/// <summary>
		///  Devuelve un Rol
		/// </summary>
		/// <returns>retorna un statusCode 200 un Rol</returns>


		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var Rol = await _unitOfWork.RolRepository.GetById(id);
			if (Rol == null)
			{
				return ResponseFactory.CreateSuccessResponse(404, "Perfil no encontrado!");
			}
			return ResponseFactory.CreateSuccessResponse(200, Rol);
		}


		/// <summary>
		///  Registra un nuevo Rol
		/// </summary>
		/// <returns>retorna un Rol registrado con un statusCode 200</returns>

		[Authorize(Policy = "Administrador")]
		[HttpPost]
		[Route("Agregar")]
		public async Task<IActionResult> Insert(RolDto dto)
		{
			var rol = new Rol(dto);
			await _unitOfWork.RolRepository.Insert(rol);
			await _unitOfWork.Complete();
			return ResponseFactory.CreateSuccessResponse(201, "Perfil registrado con exito!");
		}

		/// <summary>
		///  Actualiza un Rol
		/// </summary>
		/// <returns>retorna un Rol actualizado o un statusCode 201</returns>

		[Authorize(Policy = "Administrador")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, Rol rol)
		{
			var result = await _unitOfWork.RolRepository.Update(rol);
			if (!result)
			{
				return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el perfil");
			}
			else
			{
				await _unitOfWork.Complete();
				return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
			}
		}


		/// <summary>
		///  Elimina un Rol
		/// </summary>
		/// <returns> retorna Rol eliminado o un 500</returns>

		[Authorize(Policy = "Administrador")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var result = await _unitOfWork.RolRepository.Delete(id);
			if (!result)
			{
				return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el perfil");
			}
			else
			{
				await _unitOfWork.Complete();
				return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
			}
		}
	}
}
