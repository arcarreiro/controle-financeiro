using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [ApiController]
    [Route("api/despesas")]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaService _despesaService;

        public DespesaController(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDespesaById(int id)
        {
            var despesa = await _despesaService.GetDespesaByIdAsync(id);
            if (despesa == null)
            {
                return NotFound("Nenhuma despesa foi registrada para o usuário especificado.");
            }
            return Ok(despesa);
        }

        [Authorize]
        [HttpGet("mes/{ano}/{mes}/usuario/{usuarioId}")]
        public async Task<IActionResult> GetDespesasByMonth(int ano, int mes, int usuarioId)
        {
            var despesas = await _despesaService.GetDespesasByMonthAsync(ano, mes, usuarioId);
            var total = _despesaService.SomatorioMensal(despesas);
            return Ok(new
            {
                despesas,
                total
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddDespesa([FromBody] DespesaCreateDTO despesaDto)
        {
            var novaDespesa = await _despesaService.AddDespesaAsync(despesaDto);
            return CreatedAtAction(nameof(GetDespesaById), new { id = novaDespesa.Id }, novaDespesa);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDespesa(int id, [FromBody] DespesaUpdateDTO despesaDto)
        {
            var despesaAtualizada = await _despesaService.UpdateDespesaAsync(id, despesaDto);
            if (despesaAtualizada == null)
            {
                return NotFound("Despesa não encontrada.");
            }
            return Ok(despesaAtualizada);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespesa(int id)
        {
            var sucesso = await _despesaService.DeleteDespesaAsync(id);
            if (!sucesso)
            {
                return NotFound("Despesa não encontrada.");
            }
            return NoContent();
        }
    }
}
