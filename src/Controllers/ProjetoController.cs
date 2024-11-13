using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using GerenciadorDeTarefas.API.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GerenciadorDeTarefas.API.Controllers
{
    [ApiController]
    [Route("projeto")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;
        private readonly TokenService _tokenService;

        public ProjetoController(IProjetoService projetoService, TokenService tokenService)
        {
            _projetoService = projetoService;
            _tokenService = tokenService;
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

        [HttpGet("usuario")]
        public async Task<IActionResult> GetByUsuario()
        {
            var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _projetoService.GetByUsuarioAsync(usuarioId);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Projeto>> Create([FromBody] ProjetoDto projetoDto)
        {
            var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _projetoService.InsertAsync(usuarioId, projetoDto);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProjetoDto projetoDto)
        {
            var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _projetoService.UpdateAsync(id, usuarioId, projetoDto);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result.IsSuccess);
        }

        [Authorize]
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
