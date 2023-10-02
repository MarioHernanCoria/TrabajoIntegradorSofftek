using TrabajoIntegradorSofftek.Entities;
using TrabajoIntegradorSofftek.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TrabajoIntegradorSofftek.Services.Interfaces;
using TrabajoIntegradorSofftek.Helpers;
using TrabajoIntegradorSofftek.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabajoIntegradorSofftek.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class TrabajosController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		public TrabajosController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		/// <summary>
		///  Devuelve todos los trabajos
		/// </summary>
		/// <returns>retorna un statusCode 200 todos los trabajos</returns>


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var Trabajos = await _unitOfWork.TrabajoRepository.GetAll();
			int pageToShow = 1;
			if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
			var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
			var paginadoTrabajos = PaginateHelper.Paginate(Trabajos, pageToShow, url);

			return ResponseFactory.CreateSuccessResponse(200, paginadoTrabajos);
		}

		/// <summary>
		///  Devuelve un trabajo
		/// </summary>
		/// <returns>retorna un statusCode 200 trabajo</returns>


		[HttpGet("{id}")]
		public async Task<IActionResult> GetTrabajoById(int id)
		{
			var Trabajo = await _unitOfWork.TrabajoRepository.GetById(id);
			if (Trabajo == null)
			{
				return ResponseFactory.CreateSuccessResponse(404, "Trabajo NO encontrado!");
			}
			return ResponseFactory.CreateSuccessResponse(200, Trabajo);
		}


		/// <summary>
		///  Registra un nuevo trabajo
		/// </summary>
		/// <returns>retorna un trabajo registrado con un statosCode 201</returns>

		[Authorize(Policy = "Administrador")]
		[HttpPost]
		[Route("Agregar")]
		public async Task<IActionResult> Trabajo(TrabajoDto dto)
		{
			var trabajo = new Trabajo(dto);
			await _unitOfWork.TrabajoRepository.Insert(trabajo);
			await _unitOfWork.Complete();
			return ResponseFactory.CreateSuccessResponse(201, "Trabajo registrado con exito!");
		}

		/// <summary>
		///  Devuelve un trabajo 
		/// </summary>
		/// <returns>retorna un trabajo actualizado o un status code 201</returns>


		[Authorize(Policy = "Administrador")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Trabajo([FromRoute] int id, TrabajoDto dto)
		{
			var result = await _unitOfWork.TrabajoRepository.Update(new Trabajo(dto, id));
			if (!result)
			{
				return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el trabajo");
			}
			else
			{
				await _unitOfWork.Complete();
				return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
			}

		}

		/// <summary>
		///  Elimina un trabajo
		/// </summary>
		/// <returns> retorna trabajo eliminado o un 500</returns>

		[Authorize(Policy = "Administrador")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
			{
				var result = await _unitOfWork.TrabajoRepository.Delete(id);

				if (!result)
				{
					return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el trabajo");
				}
				else
				{
					await _unitOfWork.Complete();
					return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
				};

		}
	}
}