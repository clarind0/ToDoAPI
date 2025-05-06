using IFCE.TodoList.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace IFCE.TodoList.Domain.Interfaces;

public interface ITarefaService
{
    Task<Tarefa?> GetByIdAsync(Guid id);
    Task<IEnumerable<Tarefa>> GetByUserIdAsync(Guid  userId);
    Task<Tarefa> CreateAsync(Tarefa tarefa);
    Task<Tarefa> UpdateAsync(Tarefa tarefa);
    Task DeleteAsync(Guid id);
}