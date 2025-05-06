using System.Security.Claims;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Domain.Interfaces;
using IFCE.TodoList.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFCE.TodoList.API.Controllers;

[Authorize] // Requer autenticação para acessar as rotas
[ApiController]
[Route("api/todolists")]
public class TodoListController : ControllerBase
{
    private readonly ITodoListService _todoListService;

    public TodoListController(ITodoListService todoListService)
    {
        _todoListService = todoListService;
    }

    private Guid GetUserId() =>
        Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new UnauthorizedAccessException());

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = GetUserId();   
        var todoLists = await _todoListService.GetListByUserIdAsync(userId);
        return Ok(todoLists);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userId = GetUserId();
        var todoList = await _todoListService.GetByIdAsync(id, userId);
        if (todoList == null) return NotFound();
        return Ok(todoList);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Domain.Entities.TodoList todoList)
    {
        var userId = GetUserId();
        if (string.IsNullOrWhiteSpace(todoList.Nome))
            return BadRequest("O nome da lista é obrigatório.");

        todoList.UserId = userId;
        var newList = await _todoListService.CreateAsync(todoList);
        return CreatedAtAction(nameof(GetById), new { id = newList.Id }, newList);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Domain.Entities.TodoList todoList)
    {
        var userId = GetUserId();
        if (id != todoList.Id) return BadRequest("IDs não conferem.");
        
        var updatedList = await _todoListService.UpdateAsync(todoList, userId);
        return Ok(updatedList);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = GetUserId();
        await _todoListService.DeleteAsync(id, userId);
        return NoContent();
    }
}
