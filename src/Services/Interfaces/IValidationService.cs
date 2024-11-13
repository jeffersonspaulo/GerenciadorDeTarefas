using GerenciadorDeTarefas.API.Utils;

namespace GerenciadorDeTarefas.API.Services.Interfaces
{
    public interface IValidationService
    {
        Result Validate<T>(T dto);
    }
}
