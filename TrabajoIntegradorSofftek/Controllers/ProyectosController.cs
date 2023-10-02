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
	public class ProyectosController : ControllerBase
    {
		private readonly IUnitOfWork _unitOfWork;
		public ProyectosController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		/// <summary>
		///  Devuelve todos los Proyectos
		/// </summary>
		/// <returns>retorna un statusCode 200 todos los Proyectos</returns>


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var Proyectos = await _unitOfWork.ProyectoRepository.GetAll();
			int pageToShow = 1;
			if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
			var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
			var paginadoProyectos = PaginateHelper.Paginate(Proyectos, pageToShow, url);

			return ResponseFactory.CreateSuccessResponse(200, paginadoProyectos);
		}

		/// <summary>
		///  Devuelve un Proyecto
		/// </summary>
		/// <returns>retorna un statusCode 200 un Proyecto</returns>


		[HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var Proyecto = await _unitOfWork.ProyectoRepository.GetById(id);
			if (Proyecto == null)
			{
				return ResponseFactory.CreateErrorResponse(500, "No se encontro ningun usuario con ese id ");
			}
			await _unitOfWork.Complete();
			return ResponseFactory.CreateSuccessResponse(200, Proyecto);
		}

		/// <summary>
		///  Devuelve Proyectos por estado ingresado
		/// </summary>
		/// <returns>retorna un statusCode 200 Proyectos por estado ingresado</returns>


		[HttpGet]
		[Route("/api/Proyecto/estado/{estado}")]
		public async Task<IActionResult> GetByEstado(int estado)
		{
			var proyectos = await _unitOfWork.ProyectoRepository.GetByEstado(estado);
			if (!proyectos.Any())
			{
				return ResponseFactory.CreateSuccessResponse(404, "NO existe estado o no hay proyecto con este estado!");
			}
			return ResponseFactory.CreateSuccessResponse(200, proyectos);
		}


		/// <summary>
		///  Registra un nuevo Proyecto
		/// </summary>
		/// <param name="dto"></param>
		/// <returns>retorna un Proyecto registrado o un statusCode 200</returns>

		[Authorize(Policy = "Administrador")]
		[HttpPost]
		[Route("Agregar")]
		public async Task<IActionResult> Proyecto(ProyectoDto dto)
		{
			var proyecto = new Proyecto(dto);
			await _unitOfWork.ProyectoRepository.Insert(proyecto);
			await _unitOfWork.Complete();
			return ResponseFactory.CreateSuccessResponse(201, "Proyecto registrado con exito!");
		}


		/// <summary>
		///  Actualiza un Proyecto
		/// </summary>
		/// <returns>retorna Proyecto actualizado o un statusCode 201</returns>


		[Authorize(Policy = "Administrador")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Proyecto([FromRoute] int id, ProyectoDto dto)
		{
			var result = await _unitOfWork.ProyectoRepository.Update(new Proyecto(dto, id));
			if (!result)
			{
				return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el proyecto");
			}
			else
			{
				await _unitOfWork.Complete();
				return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
			}
		}


		/// <summary>
		///  Elimina un Proyecto
		/// </summary>
		/// <returns> retorna Proyecto eliminado o un 500</returns>
		
		[Authorize(Policy = "Administrador")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var result = await _unitOfWork.ProyectoRepository.Delete(id);
			if (!result)
			{
				return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el proyecto");
			}
			else
			{
				await _unitOfWork.Complete();
				return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
			}
		}	}
}
