using IFCE.TodoList.Domain.Repositories;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Domain.Services;
using Task = System.Threading.Tasks.Task;

namespace IFCE.TodoList.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuariorepository;

    public UsuarioService(IUsuarioRepository usuariorepository)
    {
        _usuariorepository = usuariorepository;
    }

    public async Task<Usuario?> GetByIdAsync(Guid id)
    {
        return await _usuariorepository.GetByIdAsync(id);
    }

    public async Task<Usuario?> GetByEmailAsync(string email)
    {
        return await _usuariorepository.GetByEmailAsync(email);
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _usuariorepository.GetAllAsync();
    }

    public async Task<Usuario> CreateAsync(Usuario usuario)
    {
        await _usuariorepository.AddAsync(usuario);
        await _usuariorepository.SaveChangesAsync();
        return usuario;
    }
    
    public async Task<Usuario> UpdateAsync(Usuario usuario)
    {
        await _usuariorepository.Update(usuario);
        await _usuariorepository.SaveChangesAsync();
        return usuario;
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var usuario = await _usuariorepository.GetByIdAsync(id);
        if (usuario != null)
        {
            await _usuariorepository.Delete(usuario);
            await _usuariorepository.SaveChangesAsync();
        }
    }
    
}