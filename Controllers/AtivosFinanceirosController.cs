using InvestTrack.API.Models;
using InvestTrack.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InvestTrack.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AtivosFinanceirosController : ControllerBase
    {
        private readonly IAtivoFinanceiroRepository _ativoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public AtivosFinanceirosController(IAtivoFinanceiroRepository ativoRepository, IUsuarioRepository usuarioRepository)
        {
            _ativoRepository = ativoRepository;
            _usuarioRepository = usuarioRepository;
        }
        // GET: /ativosfinanceiros/5
        [HttpGet("/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<AtivoFinanceiro>>> GetAtivosPorUsuario(int usuarioId)
        {
            var ativos = await _ativoRepository.GetByUsuarioIdAsync(usuarioId);
            return Ok(ativos);
        }

        // GET: /ativosfinanceiros/10
        [HttpGet("{id}")]
        public async Task<ActionResult<AtivoFinanceiro>> GetAtivo(int id)
        {
            var ativo = await _ativoRepository.GetByIdAsync(id);
            if (ativo == null)
            {
                return NotFound(); // HTTP 404
            }
            return Ok(ativo); // HTTP 200
        }

        // POST: /ativosfinanceiros
        [HttpPost]
        public async Task<ActionResult<AtivoFinanceiro>> CreateAtivo([FromBody] AtivoFinanceiro novoAtivo)
        {
            if (novoAtivo == null)
            {
                return BadRequest("Dados do ativo inválidos.");
            }
            var usuario = await _usuarioRepository.GetByIdAsync(novoAtivo.UsuarioId);
            if (usuario == null)
            {
                return BadRequest($"Usuário com ID {novoAtivo.UsuarioId} não existe. Não é possível criar o ativo.");
            }
            var ativoCriado = await _ativoRepository.AddAsync(novoAtivo);
            return CreatedAtAction(nameof(GetAtivo), new { id = ativoCriado.Id }, ativoCriado);
        }

        // PUT: /ativosfinanceiros/10
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAtivo(int id, [FromBody] AtivoFinanceiro ativo)
        {
            if (id != ativo.Id)
            {
                return BadRequest("ID da rota não corresponde ao ID do ativo.");
            }

            await _ativoRepository.UpdateAsync(ativo);
            return NoContent(); // HTTP 204
        }

        // DELETE: /ativosfinanceiros/10
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtivo(int id)
        {
            var ativoExistente = await _ativoRepository.GetByIdAsync(id);
            if (ativoExistente == null)
            {
                return NotFound();
            }

            await _ativoRepository.DeleteAsync(id);
            return NoContent(); // HTTP 204
        }
    }
}