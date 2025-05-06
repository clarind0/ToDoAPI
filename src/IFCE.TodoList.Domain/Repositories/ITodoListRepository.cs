using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Domain.Repositories;

public interface ITodoListRepository : IRepository<Entities.TodoList>
{
    Task<IEnumerable<Entities.TodoList>> GetListByUserIdAsync(Guid userId);
}