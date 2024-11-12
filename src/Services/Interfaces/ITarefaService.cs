﻿using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Utils;

namespace GerenciadorDeTarefas.API.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<Result<IEnumerable<Tarefa>>> GetAllAsync();
        Task<Result<Tarefa>> GetByIdAsync(int id);
        Task<Result<IEnumerable<Tarefa>>> GetByProjetoAsync(int projetoId);
        Task<Result<Tarefa>> InsertAsync(TarefaCreateDto tarefaDto);
        Task<Result> UpdateAsync(int id, TarefaUpdateDto tarefaDto);
        Task<Result> DeleteAsync(int id);
    }
}
