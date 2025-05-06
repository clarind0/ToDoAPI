using System.Linq.Expressions;
using IFCE.TodoList.Domain.Repositories;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Domain.Interfaces;

namespace IFCE.TodoList.Application.Services;

public class TarefaService : ITarefaService
{
    private readonly ITarefaRepository _tarefaRepository;

    public TarefaService(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task<Tarefa?> GetByIdAsync(Guid id, Guid userId)
    {
        var tarefa = await _tarefaRepository.GetByIdAsync(id);
        return tarefa?.UserId == userId ? tarefa : null;
    }

    public Task<Tarefa?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Tarefa>> GetByUserIdAsync(Guid userId)
    {
        return await _tarefaRepository.GetTasksByUserIdAsync(userId);
    }

    public async Task<Tarefa> CreateAsync(Tarefa tarefa)
    {
        // Validar nome
        if (string.IsNullOrWhiteSpace(tarefa.Descricao))
            throw new ArgumentException("O nome da tarefa não pode ser vazio.");

        // Validar UserId
        if (tarefa.UserId == Guid.Empty)
            throw new ArgumentException("O ID do usuário é inválido.");

        await _tarefaRepository.AddAsync(tarefa);
        await _tarefaRepository.SaveChangesAsync();
        return tarefa;
    }

    public Task<Tarefa> UpdateAsync(Tarefa tarefa)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Tarefa> UpdateAsync(Tarefa tarefa, Guid userId)
    {
        var existingTarefa = await _tarefaRepository.GetByIdAsync(tarefa.Id);

        if (existingTarefa == null || existingTarefa.UserId != userId)
            throw new KeyNotFoundException("Tarefa não encontrada.");

        existingTarefa.Descricao = tarefa.Descricao;
        existingTarefa.Concluded = tarefa.Concluded;

        await _tarefaRepository.Update(existingTarefa);
        await _tarefaRepository.SaveChangesAsync();
        return existingTarefa;
    }

    public async Task DeleteAsync(Guid id, Guid userId)
    {
        var tarefa = await _tarefaRepository.GetByIdAsync(id);

        if (tarefa == null || tarefa.UserId != userId)
            throw new KeyNotFoundException("Tarefa não encontrada.");

        await _tarefaRepository.Delete(tarefa);
        await _tarefaRepository.SaveChangesAsync();
    }
}
