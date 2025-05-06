using IFCE.TodoList.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace IFCE.TodoList.Domain.Services;

public interface IUsuarioService
{
    Task<Usuario?> GetByIdAsync(Guid id);
    Task<Usuario?> GetByEmailAsync(string email);
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario> CreateAsync(Usuario usuario);
    Task<Usuario> UpdateAsync(Usuario usuario);
    Task DeleteAsync(Guid id);
}