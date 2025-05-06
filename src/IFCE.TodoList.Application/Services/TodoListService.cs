using IFCE.TodoList.Domain.Repositories;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Domain.Interfaces;

namespace IFCE.TodoList.Application.Services;

public class TodoListService : ITodoListService
{
    private readonly ITodoListRepository _todoListRepository;

    public TodoListService(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<Domain.Entities.TodoList?> GetByIdAsync(Guid id, Guid userId)
    {
        var todoList = await _todoListRepository.GetByIdAsync(id);
        return todoList?.UserId == userId ? todoList : null;
    }

    public async Task<IEnumerable<Domain.Entities.TodoList>> GetListByUserIdAsync(Guid userId)
    {
        return await _todoListRepository.GetListByUserIdAsync(userId);
    }

    public async Task<Domain.Entities.TodoList> CreateAsync(Domain.Entities.TodoList todoList)
    {
        // Validar nome
        if (string.IsNullOrWhiteSpace(todoList.Nome))
            throw new ArgumentException("O nome da lista não pode ser vazio.");

        // Validar UserId
        if (todoList.UserId == Guid.Empty)
            throw new ArgumentException("O ID do usuário é inválido.");

        await _todoListRepository.AddAsync(todoList);
        await _todoListRepository.SaveChangesAsync();
        return todoList;
    }

    public async Task<Domain.Entities.TodoList> UpdateAsync(Domain.Entities.TodoList todoList, Guid userId)
    {
        var existingTodoList = await _todoListRepository.GetByIdAsync(todoList.Id);

        if (existingTodoList == null || existingTodoList.UserId != userId)
            throw new KeyNotFoundException("Lista não encontrada.");

        existingTodoList.Nome = todoList.Nome;

        await _todoListRepository.Update(existingTodoList);
        await _todoListRepository.SaveChangesAsync();
        return existingTodoList;
    }

    public async Task DeleteAsync(Guid id, Guid userId)
    {
        var todoList = await _todoListRepository.GetByIdAsync(id);

        if (todoList == null || todoList.UserId != userId)
            throw new KeyNotFoundException("Lista não encontrada.");

        await _todoListRepository.Delete(todoList);
        await _todoListRepository.SaveChangesAsync();
    }
}
