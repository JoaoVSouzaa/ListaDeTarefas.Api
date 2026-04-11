using ListaDeTarefas.Api.DTOs;
using ListaDeTarefas.Api.Services;
using ListaDeTarefas.Api.Enums;
using Microsoft.AspNetCore.Mvc; 

namespace ListaDeTarefas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _service;
        public TarefasController(ITarefaService service)
        {
            _service = service;
        }
        //GET: api/tarefa
        [HttpGet]
        public async Task<IActionResult> ObterTodasTarefas()
        {
            var tarefas = await _service.ObterTodasTarefasAsync();
            return Ok(tarefas);
        }

        // GET: api/tarefas/status?status=1
        [HttpGet("status")]
        public async Task<IActionResult> ObterPorStatus([FromQuery] StatusTarefa status)
        {
            var tarefas = await _service.ObterPorStatusAsync(status);
            return Ok(tarefas);
        }

        //GET: api/tarefas/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var tarefa = await _service.ObterPorIdAsync(id);

            if (tarefa is null)
                return NotFound();

            return Ok(tarefa);
        }

        // POST: api/tarefas
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarTarefaDto dto)
        {
            var tarefa = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        // PUT: api/tarefas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarTarefaDto dto)
        {
            var atualizado = await _service.AtualizarAsync(id, dto);

            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/tarefas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var removido = await _service.RemoverAsync(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }

    }
}
