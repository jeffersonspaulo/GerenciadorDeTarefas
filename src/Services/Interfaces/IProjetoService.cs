using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Utils;

namespace GerenciadorDeTarefas.API.Services.Interfaces
{
    public interface IProjetoService
    {
        Task<Result<IEnumerable<Projeto>>> GetAllAsync();
        Task<Result<Projeto>> GetByIdAsync(int id);
        Task<Result<IEnumerable<Projeto>>> GetByUsuarioAsync(string usuarioId);
        Task<Result<Projeto>> InsertAsync(string usuarioId, ProjetoDto projetoDto);
        Task<Result> UpdateAsync(int id, string usuarioId, ProjetoDto projetoDto);
        Task<Result> DeleteAsync(int id);
    }
}
