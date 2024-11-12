using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.API.Controllers
{
    [ApiController]
    [Route("relatorio")]
    public class RelatorioController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public RelatorioController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _projetoService.GetAllAsync();

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _projetoService.GetByIdAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuario(int usuarioId)
        {
            var result = await _projetoService.GetByUsuarioAsync(usuarioId);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult<Projeto>> Create([FromBody] ProjetoDto projetoDto)
        {
            var result = await _projetoService.InsertAsync(projetoDto);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProjetoDto projetoDto)
        {
            var result = await _projetoService.UpdateAsync(id, projetoDto);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.IsSuccess);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projetoService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.IsSuccess);
        }
    }
}
