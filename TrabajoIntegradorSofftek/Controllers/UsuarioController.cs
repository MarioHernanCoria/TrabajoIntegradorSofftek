﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(IUnitOfWork unitOfWork, ILogger<UsuarioController> logger) 
        {
			_logger = logger;
            _unitOfWork = unitOfWork;
        }


		/// <summary>
		///  Devuelve todos los Usuarios
		/// </summary>
		/// <returns>retorna un statusCode 200 todos los Usuarios</returns>

		
		[HttpGet]
        public async Task<IActionResult> GetAll()
        {
			try
			{
				var Usuarios = await _unitOfWork.UsuarioRepository.GetAll();
				int pageToShow = 1;

				if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

				var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
				var paginateUsuarios = PaginateHelper.Paginate(Usuarios, pageToShow, url);

                _logger.LogInformation("Se obtuvieron todos los usuarios correctamente.");

                return ResponseFactory.CreateSuccessResponse(200, paginateUsuarios);
			}
			catch (Exception ex) 
			{
                _logger.LogError(ex, "Ocurrió un error al obtener los usuarios.");
                return ResponseFactory.CreateErrorResponse(500, "Ocurrió un error interno.");
            }
		}

		/// <summary>
		/// Devuelve el Usuario solicitado 
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Retorna 200 si se obtuvo usuario por id o 500 si no existe usuario con ese id</returns>

		
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			try
			{
				var Usuario = await _unitOfWork.UsuarioRepository.GetById(id);
				if (Usuario == null)
				{
                    Log.Information("No se encontró ningún usuario con el ID {UserId}", id);
                    
                }
				await _unitOfWork.Complete();

				Log.Information("Se encontro el Usuario");
				return ResponseFactory.CreateSuccessResponse(200, Usuario);
			}
			catch (Exception ex)
			{
                Log.Error(ex, "Ocurrió un error al obtener el usuario con ID {UserId}.", id);
                return ResponseFactory.CreateErrorResponse(500, "Ocurrió un error interno.");
            }

        }



		/// <summary>
		///  Registra un nuevo Usuario
		/// </summary>
		/// <returns>retorna Usuario registrado con un statusCode 200</returns>

		[Authorize(Policy = "Administrador")]
		[HttpPost]
		[Route("Agregar")]
		public async Task<IActionResult> Usuario(UsuarioDto dto)
		{
			if (await _unitOfWork.UsuarioRepository.UsuarioEx(dto.Email)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el mail: {dto.Email}");

			var Usuario = new Usuario(dto);
			await _unitOfWork.UsuarioRepository.Insert(Usuario);

			await _unitOfWork.Complete();
			return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
		}


		/// <summary>
		///  Actualiza un Usuario
		/// </summary>
		/// <returns>retorna un Usuario actualizado o un statusCode 201</returns>


		//[Authorize(Policy = "Administrador")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Usuario([FromRoute] int id, UsuarioDto dto)
		{
			var result = await _unitOfWork.UsuarioRepository.Update(new Usuario(dto, id));

			if (!result)
			{
				return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el usuario");
			}
			else
			{
				await _unitOfWork.Complete();
				return ResponseFactory.CreateSuccessResponse(200, "Actualizado");

			}
		}

		/// <summary>
		///  Elimina un Usuario
		/// </summary>
		/// <returns> retorna Usuario eliminado o un 500</returns>


		[Authorize(Policy = "Administrador")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var result = await _unitOfWork.UsuarioRepository.Delete(id);

			if (!result)
			{
				return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
			}
			else
			{
				await _unitOfWork.Complete();
				return ResponseFactory.CreateSuccessResponse(200, "Eliminado");

			}

		}
	}
}
