using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.API.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _tarefaService.GetAllAsync();

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _tarefaService.GetByIdAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpGet("projeto/{projetoId}")]
        public async Task<IActionResult> GetByUsuario(int projetoId)
        {
            var result = await _tarefaService.GetByProjetoAsync(projetoId);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> Create([FromBody] TarefaCreateDto tarefaDto)
        {
            var result = await _tarefaService.InsertAsync(tarefaDto);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TarefaUpdateDto tarefaDto)
        {
            var result = await _tarefaService.UpdateAsync(id, tarefaDto);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.IsSuccess);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tarefaService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.IsSuccess);
        }
    }
}
