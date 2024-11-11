using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Services;
using GerenciadorDeTarefas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.API.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        private readonly ILogger<TarefaController> _logger;
        private readonly ITarefaService _tarefaService;

        public TarefaController(ILogger<TarefaController> logger, ITarefaService tarefaService)
        {
            _logger = logger;
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tarefas = await _tarefaService.GetAllAsync();

                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Error = "Ocorreu um erro durante a requisição.", Descricao = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var tarefa = await _tarefaService.GetByIdAsync(id);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Error = "Ocorreu um erro durante a requisição.", Descricao = ex.Message });
            }
        }

        [HttpGet("projeto/{projetoId}")]
        public async Task<IActionResult> GetByUsuario(int projetoId)
        {
            try
            {
                var tarefas = await _tarefaService.GetByProjetoAsync(projetoId);

                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Error = "Ocorreu um erro durante a requisição.", Descricao = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> Create([FromBody] TarefaCreateDto tarefaDto)
        {
            try
            {
                var tarefa = await _tarefaService.InsertAsync(tarefaDto);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Error = "Ocorreu um erro durante a requisição.", Descricao = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TarefaCreateDto tarefaDto)
        {
            try
            {
                await _tarefaService.UpdateAsync(id, tarefaDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Error = "Ocorreu um erro durante a requisição.", Descricao = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tarefaService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Error = "Ocorreu um erro durante a requisição.", Descricao = ex.Message });
            }
        }
    }
}
