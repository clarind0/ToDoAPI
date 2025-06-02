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
}