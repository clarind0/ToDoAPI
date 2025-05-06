using IFCE.TodoList.Domain.Repositories;
using IFCE.TodoList.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IFCE.TodoList.Infra.Data.Repositories;

public class TodoListRepository : Repository<Domain.Entities.TodoList>, ITodoListRepository
{
    private readonly ApplicationDbContext _context;

    public TodoListRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domain.Entities.TodoList>> GetListByUserIdAsync(Guid userId)
    {
        return await _context.TodoLists.Where(x => x.UserId == userId).ToListAsync();
    }
}