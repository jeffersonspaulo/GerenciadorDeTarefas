using FluentValidation;
using GerenciadorDeTarefas.API.Models.Dtos;

namespace GerenciadorDeTarefas.API.Validators
{
    public class ProjetoValidator : AbstractValidator<ProjetoDto>
    {
        public ProjetoValidator()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("O título do projeto precisa ser preenchido.")
                .NotNull().WithMessage("O título do projeto não pode ser nulo.");
        }
    }
}
