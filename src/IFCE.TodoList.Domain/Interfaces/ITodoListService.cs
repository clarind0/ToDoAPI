using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Domain.Interfaces;

public interface ITodoListService
{
    Task<Entities.TodoList?> GetByIdAsync(Guid id, Guid userId);
    Task<IEnumerable<Entities.TodoList>> GetListByUserIdAsync(Guid userId);
    Task<Entities.TodoList> CreateAsync(Entities.TodoList todoList);
    Task<Entities.TodoList> UpdateAsync(Entities.TodoList todoList, Guid userId);
    Task DeleteAsync(Guid id, Guid userId);
}