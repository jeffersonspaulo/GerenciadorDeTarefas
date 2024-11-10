using TaskManager.API.Models.Dtos;
using TaskManager.API.Services.Interfaces;
using TaskManager.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("projeto")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projetoService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projetoService)
        {
            _logger = logger;
            _projetoService = projetoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //var createdOrder = await _orderService.CreateAsync(orderDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request.", Description = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //var createdOrder = await _orderService.CreateAsync(orderDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request.", Description = ex.Message });
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuario(int usuarioId)
        {
            try
            {
                //var createdOrder = await _orderService.CreateAsync(orderDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request.", Description = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Project>> Create([FromBody] ProjectDto projetoDto)
        {
            try
            {
                //var createdOrder = await _orderService.CreateAsync(orderDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request.", Description = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProjectDto projetoDto)
        {
            try
            {
                //await _orderService.UpdateAsync(id, orderDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request.", Description = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                //await _orderService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }
    }
}
