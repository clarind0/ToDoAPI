using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Domain.Repositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario?> GetByEmailAsync(string email);
}