using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.API.Data.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _context;

        public RelatorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RelatorioUsuarioMediaDto>> CalcularMediaTarefasConcluidasPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            if (dataFim == DateTime.MinValue) 
                dataFim = DateTime.Now;

            var tarefasComHistorico = await _context.TarefasHistorico
                .Where(h =>
                    h.TarefaStatus == TarefaStatus.Concluida &&
                    (h.DataInclusao >= dataInicio) &&
                    (h.DataInclusao <= dataFim)
                )
                .GroupBy(h => h.TarefaId)
                .Select(g => new
                {
                    TarefaId = g.Key,
                    HistoricoConclusao = g
                        .OrderBy(h => h.DataInclusao)
                        .FirstOrDefault() 
                })
                .ToListAsync();

            var mediasPorUsuario = tarefasComHistorico
                .Where(t => t.HistoricoConclusao != null)
                .GroupBy(t => t.HistoricoConclusao.UsuarioId)
                .Select(g => new RelatorioUsuarioMediaDto
                {
                    UsuarioId = g.Key,
                    Media = g.Count()
                })
                .ToList();

            return mediasPorUsuario;
        }

        public async Task<IEnumerable<ProjetoQuantidadeDto>> ObterTarefasConcluidasPorProjetoAsync(RelatorioTarefasPorProjetoDto relatorioDto)
        {
            var resultados = await _context.Tarefas
                .Where(t => t.ProjetoId == relatorioDto.ProjetoId &&
                            t.TarefaHistoricos.Any(h => h.TarefaStatus == TarefaStatus.Concluida &&
                                                         h.DataInclusao >= relatorioDto.DataInicio && h.DataInclusao <= relatorioDto.DataFim))
                .GroupBy(t => t.ProjetoId)
                .Select(g => new ProjetoQuantidadeDto
                {
                    ProjetoId = g.Key,
                    Quantidade = g.Count()
                })
                .ToListAsync();

            return resultados;
        }

        public async Task<IEnumerable<RelatorioUsuarioQuantidade>> ObterUsuariosMaisProdutivosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await _context.TarefasHistorico
                .Where(h => h.TarefaStatus == TarefaStatus.Concluida &&
                            h.DataInclusao >= dataInicio && h.DataInclusao <= dataFim)
                .GroupBy(h => h.UsuarioId)
                .OrderByDescending(g => g.Count())
                .Select(g => new RelatorioUsuarioQuantidade
                {
                    UsuarioId = g.Key,
                    QuantidadeTarefasConcluidas = g.Count()
                })
                .ToListAsync();
        }

        public async Task<double> CalcularMediaTarefasCriadasPorDiaAsync()
        {
            var totalTarefas = await _context.Tarefas.CountAsync();
            var dataMaisAntiga = await _context.Tarefas.MinAsync(t => t.DataCriacao);
            var diasTotais = (DateTime.Now - dataMaisAntiga).TotalDays;

            if (diasTotais <= 0) return 0;

            return totalTarefas / diasTotais;
        }

        public async Task<IEnumerable<Projeto>> ObterProjetosAtrasadosAsync()
        {
            return await _context.Projetos
                .Where(p => p.Tarefas.Any(t => t.DataVencimento < DateTime.Now && t.TarefaStatus != TarefaStatus.Concluida))
                .ToListAsync();
        }
    }
}
