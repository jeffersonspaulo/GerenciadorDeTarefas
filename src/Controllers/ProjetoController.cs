using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.API.Controllers
{
    [ApiController]
    [Route("projeto")]
    public class ProjetoController : ControllerBase
    {
        private readonly ILogger<ProjetoController> _logger;
        private readonly IProjetoService _projetoService;

        public ProjetoController(ILogger<ProjetoController> logger, IProjetoService projetoService)
        {
            _logger = logger;
            _projetoService = projetoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var projetos = await _projetoService.GetAllAsync();

                return Ok(projetos);
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
                var projeto = await _projetoService.GetByIdAsync(id);

                return Ok(projeto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Error = "Ocorreu um erro durante a requisição.", Descricao = ex.Message });
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuario(int usuarioId)
        {
            try
            {
                var projetos = await _projetoService.GetByUsuarioAsync(usuarioId);

                return Ok(projetos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Error = "Ocorreu um erro durante a requisição.", Descricao = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Projeto>> Create([FromBody] ProjetoDto projetoDto)
        {
            try
            {
                var projeto = await _projetoService.InsertAsync(projetoDto);

                return Ok(projeto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { Error = "Ocorreu um erro durante a requisição.", Descricao = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProjetoDto projetoDto)
        {
            try
            {
                await _projetoService.UpdateAsync(id, projetoDto);

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
                await _projetoService.DeleteAsync(id);

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
