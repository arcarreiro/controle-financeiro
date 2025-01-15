using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [ApiController]
    [Route("api/receitas")]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaService _receitaService;
        

        public ReceitaController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceitaById(int id)
        {
            var receita = await _receitaService.GetReceitaByIdAsync(id);
            if (receita == null)
            {
                return NotFound("Nenhuma receita foi registrada para o usuário especificado.");
            }
            return Ok(receita);
        }

        [HttpGet("mes/{ano}/{mes}/usuario/{usuarioId}")]
        [Authorize]
        public async Task<IActionResult> GetReceitasByMonth(int ano, int mes, int usuarioId)
        {
            var receitas = await _receitaService.GetReceitasByMonthAsync(ano, mes, usuarioId);
            var total = _receitaService.SomatorioMensal(receitas);
            return Ok(new
            {
                receitas, 
                total
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddReceita([FromBody] ReceitaCreateDTO receitaDto)
        {

            var novaReceita = await _receitaService.AddReceitaAsync(receitaDto);
            return CreatedAtAction(nameof(GetReceitaById), new { id = novaReceita.Id }, novaReceita);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceita(int id, [FromBody] ReceitaUpdateDTO receitaDto)
        {
            var receitaAtualizada = await _receitaService.UpdateReceitaAsync(id, receitaDto);
            if (receitaAtualizada == null)
            {
                return NotFound("Receita não encontrada.");
            }
            return Ok(receitaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceita(int id)
        {
            var sucesso = await _receitaService.DeleteReceitaAsync(id);
            if (!sucesso)
            {
                return NotFound("Receita não encontrada.");
            }
            return NoContent();
        }
    }
}
