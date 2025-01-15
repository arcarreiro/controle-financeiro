using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Application.Services;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthController(IAuthService authService, IUsuarioRepository usuarioRepository)
        {
            _authService = authService;
            _usuarioRepository = usuarioRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto, [FromServices] JwtService jwtService)
        {
            var user = await _usuarioRepository.GetByEmail(loginDto.Email);
            if (user == null) return NotFound("Usuário não encontrado.");

            var authenticated = await _authService.ValidateUserCredentials(loginDto.Email, loginDto.Password);


            if (!authenticated)
            {
                return Unauthorized("Credenciais inválidas.");
            } try
            {
                var token = jwtService.GenerateToken(user);

                var response = new { token = token, userId = user.Id, name = user.Nome, email = user.Email.Endereco };
                return Ok(response);
            } catch
            {
                return StatusCode(500, "Internal Error");
            }
        }
    }
}
