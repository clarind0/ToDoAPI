using IFCE.TodoList.Domain.Repositories;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace IFCE.TodoList.Infra.Data.Repositories;

public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
{
    private readonly ApplicationDbContext _context;
    
    public TarefaRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Tarefa>> GetTasksByUserIdAsync(Guid userId)
    {
        return await _context.Tarefas.Where(t => t.UserId == userId).ToListAsync();
    }
}