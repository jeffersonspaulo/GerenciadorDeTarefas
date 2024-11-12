using FluentValidation;
using FluentValidation.Results;
using GerenciadorDeTarefas.API.Utils;

namespace GerenciadorDeTarefas.API.Services
{
    public class ValidationService
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Result Validate<T>(T dto)
        {
            var validator = _serviceProvider.GetService<IValidator<T>>();

            if (validator == null)
            {
                throw new InvalidOperationException($"Nenhum validator encontrado com o nome {typeof(T).Name}");
            }

            ValidationResult result = validator?.Validate(dto);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                var errorMessage = string.Join("; ", errors);
                return Result.Failure(errorMessage);
            }

            return Result.Success();
        }
    }
}
