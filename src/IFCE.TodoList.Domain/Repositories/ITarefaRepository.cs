using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Domain.Repositories;

public interface ITarefaRepository : IRepository<Tarefa>
{
    Task SaveChangesAsync();
}