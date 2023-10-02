
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofftek.DTOs;
using TrabajoIntegradorSofftek.Entities;
using TrabajoIntegradorSofftek.Helpers;
using TrabajoIntegradorSofftek.Infrastructure;
using TrabajoIntegradorSofftek.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabajoIntegradorSofftek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class ServiciosController : ControllerBase
    {
		private readonly IUnitOfWork _unitOfWork;
		public ServiciosController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		/// <summary>
		///  Devuelve todos los Servicios
		/// </summary>
		/// <returns>retorna un statusCode 200 todos los Servicios</returns>


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var Servicios = await _unitOfWork.ServicioRepository.GetAll();
			int pageToShow = 1;
			if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
			var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
			var paginadoServicios = PaginateHelper.Paginate(Servicios, pageToShow, url);

			return ResponseFactory.CreateSuccessResponse(200, paginadoServicios);
		}

		/// <summary>
		///  Devuelve todos los Servicios activos
		/// </summary>
		/// <returns>retorna un statusCode 200 todos los Servicios activos</returns>


		[HttpGet]
		[Route("estado/{estado}")]
		public async Task<IActionResult> GetByEstado(bool estado)
		{
			var servicios = await _unitOfWork.ServicioRepository.GetByEstado(estado);
			if (!servicios.Any())
			{
				return ResponseFactory.CreateSuccessResponse(404, "NO existen servicios en esta condición " + estado);
			}
			await _unitOfWork.Complete();
			return ResponseFactory.CreateSuccessResponse(200, servicios);
		}

		/// <summary>
		///  Devuelve un Servicio
		/// </summary>
		/// <returns>retorna un statusCode 200 un Servicio</returns>


		[HttpGet("{id}")]
		public async Task<IActionResult> GetServicioById([FromRoute]int id)
		{
			var servicio = await _unitOfWork.ServicioRepository.GetById(id);
			if (servicio == null)
			{
				return ResponseFactory.CreateSuccessResponse(404, "Servicio NO encontrado!");
			}
			await _unitOfWork.Complete();
			return ResponseFactory.CreateSuccessResponse(200, servicio);
		}


		/// <summary>
		///  Registra un nuevo Servicio 
		/// </summary>
		/// <returns>retorna un Servicio registrado con un statusCode 200</returns>

		[Authorize(Policy = "Administrador")]
		[HttpPost]
		[Route("Agregar")]
		public async Task<IActionResult> Servicio(ServicioDto dto)
		{
			var servicio = new Servicio(dto);
			await _unitOfWork.ServicioRepository.Insert(servicio);
			await _unitOfWork.Complete();
			return ResponseFactory.CreateSuccessResponse(201, "Servicio registrado con exito!");
		}

		/// <summary>
		///  Actualiza un Servicio
		/// </summary>
		/// <returns>retorna Servicio actualizado o un statusCode 201</returns>

		[Authorize(Policy = "Administrador")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Servicio([FromRoute] int id, ServicioDto dto)
		{
			var result = await _unitOfWork.ServicioRepository.Update(new Servicio(dto, id));
			if (!result)
			{
				return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el servicio");
			}
			else
			{
				await _unitOfWork.Complete();
				return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
			}
		}

		/// <summary>
		///  Elimina un Servicio
		/// </summary>
		/// <returns> retorna Servicio eliminado o un 500</returns>


		[Authorize(Policy = "Administrador")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var result = await _unitOfWork.ServicioRepository.Delete(id);
			if (!result)
			{
				return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el servicio");
			}
			else
			{
				await _unitOfWork.Complete();
				return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
			}
		}
	}
}
