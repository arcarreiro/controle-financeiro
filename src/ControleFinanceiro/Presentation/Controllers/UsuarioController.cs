using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Core.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Presentation.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        ///<summary>
        ///Busca um usuário pelo ID.
        ///</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuario);
        }

        ///<summary>
        ///Cria um novo usuário.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddUsuarioAsync([FromBody] UsuarioRegisterDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Todos os campos devem ser informados.");
            }

            var novoUsuario = await _usuarioService.AddUsuarioAsync(usuarioDTO);

            return CreatedAtAction(nameof(GetUsuarioById), new { id = novoUsuario.Id }, novoUsuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UsuarioUpdateDTO usuarioUpdate)
        {
            var usuarioAtualizado = await _usuarioService.UpdateUsuarioAsync(id, usuarioUpdate);
            if (usuarioAtualizado == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(usuarioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var result = await _usuarioService.DeleteUsuarioAsync(id);
            if (!result)
            {
                return NotFound("Usuário não encontrado.");
            }

            return NoContent();  
        }
    }
}
