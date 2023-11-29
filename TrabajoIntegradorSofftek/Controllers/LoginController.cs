using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoIntegradorSofftek.DTOs;
using TrabajoIntegradorSofftek.Helpers;
using TrabajoIntegradorSofftek.Services.Interfaces;

namespace TrabajoIntegradorSofftek.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
    [Authorize]

	public class LoginController : ControllerBase
	{
        private readonly ILogger<LoginController> _logger;
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration, ILogger<LoginController> logger)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
            _logger = logger;
		}

		/// <summary>
		///  Se loguea el usuario
		/// </summary>
		/// <returns>el token del usuario</returns>
        /// 
		[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            try
            {
                var usuarioCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);
                if (usuarioCredentials is null)
                {
                    _logger.LogInformation("Las credenciales son incorrectas para el usuario: {Email}", dto.Email);
                    return Unauthorized("Las credenciales son incorrectas");
                }

                var token = _tokenJwtHelper.GenerateToken(usuarioCredentials);

                var usuario = new UsuarioLoginDto()
                {
                    Nombre = usuarioCredentials.Nombre,
                    Email = usuarioCredentials.Email,
                    Token = token
                };

                _logger.LogInformation("Inicio de sesión exitoso para el usuario: {Email}", usuario.Email);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Se produjo un error al procesar la solicitud");
                return StatusCode(500, new { Message = "Se produjo un error interno", Details = ex.Message });
            }
        }
    }
}
