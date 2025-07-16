using InvestTrack.API.Models;
using InvestTrack.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InvestTrack.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        // GET: /usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _repository.GetAllAsync();
            return Ok(usuarios);
        }

        // GET: /usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado."); // HTTP 404
            }
            return Ok(usuario); // HTTP 200
        }

        // POST: /usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario([FromBody] Usuario novoUsuario)
        {
            if (novoUsuario == null)
            {
                return BadRequest("Dados do usuário inválidos."); // HTTP 400
            }

            await _repository.AddAsync(novoUsuario);
            
            return CreatedAtAction(nameof(GetUsuario), new { id = novoUsuario.Id }, novoUsuario);
        }

        // PUT: /usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest("ID da rota não corresponde ao ID do usuário.");
            }

            await _repository.UpdateAsync(usuario);
            return NoContent(); // HTTP 204 - Sucesso, sem conteúdo para retornar
        }

        // DELETE: /usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuarioExistente = await _repository.GetByIdAsync(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent(); // HTTP 204
        }
    }
}