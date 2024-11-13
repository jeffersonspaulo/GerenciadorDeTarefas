using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GerenciadorDeTarefas.API.Controllers
{
    [Authorize(Roles = "gerente")]
    [ApiController]
    [Route("relatorio")]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet("media-tarefas-concluidas")]
        public async Task<ActionResult<IEnumerable<RelatorioUsuarioMediaDto>>> MediaTarefasConcluidasAsync([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
            var resultado = await _relatorioService.CalcularMediaTarefasConcluidasPeriodoAsync(dataInicio, dataFim);

            if (resultado.IsSuccess)
            {
                return Ok(resultado.Data);
            }
            return BadRequest(resultado.ErrorMessage);
        }

        [HttpGet("tarefas-concluidas-por-projeto")]
        public async Task<ActionResult<IEnumerable<ProjetoQuantidadeDto>>> TarefasConcluidasPorProjetoAsync([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim, [FromQuery] int projetoId)
        {
            var relatorioDto = new RelatorioTarefasPorProjetoDto
            {
                DataInicio = dataInicio,
                DataFim = dataFim,
                ProjetoId = projetoId
            };

            var resultado = await _relatorioService.ObterTarefasConcluidasPorProjetoAsync(relatorioDto);

            if (resultado.IsSuccess)
            {
                return Ok(resultado.Data);
            }
            return BadRequest(resultado.ErrorMessage);
        }

        [HttpGet("usuarios-mais-produtivos")]
        public async Task<ActionResult<IEnumerable<RelatorioUsuarioQuantidade>>> UsuariosProdutivosPorPeriodoAsync([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
            var resultado = await _relatorioService.ObterUsuariosMaisProdutivosPorPeriodoAsync(dataInicio, dataFim);

            if (resultado.IsSuccess)
            {
                return Ok(resultado.Data);
            }
            return BadRequest(resultado.ErrorMessage);
        }

        [HttpGet("media-tarefas-criadas-dia")]
        public async Task<ActionResult<double>> MediaTarefasCriadasPorDiaAsync()
        {
            var resultado = await _relatorioService.CalcularMediaTarefasCriadasPorDiaAsync();

            if (resultado.IsSuccess)
            {
                return Ok(resultado.Data);
            }
            return BadRequest(resultado.ErrorMessage);
        }

        [HttpGet("projetos-atrasados")]
        public async Task<ActionResult<IEnumerable<Projeto>>> ProjetosAtrasadosAsync()
        {
            var resultado = await _relatorioService.ObterProjetosAtrasadosAsync();

            if (resultado.IsSuccess)
            {
                return Ok(resultado.Data);
            }
            return BadRequest(resultado.ErrorMessage);
        }
    }
}
