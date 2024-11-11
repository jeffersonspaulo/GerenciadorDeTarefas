using FluentValidation;
using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Services.Interfaces;

namespace GerenciadorDeTarefas.API.Validators
{
    public class TarefaValidator : AbstractValidator<TarefaCreateDto>
    {
        private readonly IProjetoService _projetoService;

        public TarefaValidator(IProjetoService projetoService)
        {
            _projetoService = projetoService;

            RuleFor(t => t.Prioridade)
                .IsInEnum().WithMessage("A prioridade deve ser 1-Baixa, 2-Média ou 3-Alta.");

            //RuleFor(t => t)
            //    .MustAsync(async (tarefa, cancellation) =>
            //        await _projetoService.ObterQuantidadeDeTarefas(tarefa.ProjetoId) < 20)
            //    .WithMessage("O projeto já atingiu o limite máximo de 20 tarefas.");
        }
    }
}
