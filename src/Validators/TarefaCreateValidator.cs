using FluentValidation;
using GerenciadorDeTarefas.API.Models.Dtos;

namespace GerenciadorDeTarefas.API.Validators
{
    public class TarefaCreateValidator : AbstractValidator<TarefaCreateDto>
    {
        public TarefaCreateValidator()
        {
            RuleFor(x => x.UsuarioId)
                .GreaterThan(0)
                .WithMessage("A tarefa precisa ser vinculada a um UsuarioId.");

            RuleFor(x => x.ProjetoId)
                .GreaterThan(0)
                .WithMessage("A tarefa precisa ser vinculada a um ProjetoId.");

            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("O título do projeto precisa ser preenchido.")
                .NotNull().WithMessage("O título do projeto não pode ser nulo.");

            RuleFor(x => x.DataVencimento)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de vencimento deve ser igual ou posterior à data atual.");

            RuleFor(t => t.TarefaStatus)
                .IsInEnum().WithMessage("A prioridade deve ser 1-Pendente, 2-Em Andamento ou 3-Concluída.");

            RuleFor(t => t.Prioridade)
                .IsInEnum().WithMessage("A prioridade deve ser 1-Baixa, 2-Média ou 3-Alta.");
        }
    }
}
