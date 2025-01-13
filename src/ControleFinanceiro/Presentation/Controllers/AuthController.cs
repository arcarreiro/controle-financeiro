using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Application.Services;
using ControleFinanceiro.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var authenticated = await _authService.ValidateUserCredentials(loginDto.Email, loginDto.Password);

            if (authenticated)
            {
                var token = await _authService.GenerateToken(loginDto.Email);
                return Ok(new { token });
            } else
            {
                return Unauthorized("Credenciais inválidas.");
            }
        }
    }
}
