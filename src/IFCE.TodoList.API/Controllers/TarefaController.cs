using System.Security.Claims;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Domain.Interfaces;
using IFCE.TodoList.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFCE.TodoList.API.Controllers;

[Authorize]
[ApiController]
[Route("api/tarefas")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _tarefaService;

    public TarefaController(ITarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    private Guid GetUserId() =>
        Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new UnauthorizedAccessException());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var tarefa = await _tarefaService.GetByIdAsync(id);
        if (tarefa == null) return NotFound();
        return Ok(tarefa);
    }

    [HttpGet("lista/{todoListId:guid}")]
    public async Task<IActionResult> GetByTodoList(Guid assignmentListId)
    {
        var userId = GetUserId();
        var tarefas = await _tarefaService.GetByUserIdAsync(userId);
        return Ok(tarefas.Where(t => t.AssignmentListId == assignmentListId));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Tarefa tarefa)
    {
        var userId = GetUserId();
        if (tarefa.AssignmentListId == Guid.Empty) return BadRequest("Lista de tarefas inválida.");

        tarefa.UserId = userId;
        var newTarefa = await _tarefaService.CreateAsync(tarefa);
        return CreatedAtAction(nameof(GetById), new { id = newTarefa.Id }, newTarefa);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Tarefa tarefa)
    {
        if (id != tarefa.Id) return BadRequest("IDs não conferem.");
        
        var updatedTarefa = await _tarefaService.UpdateAsync(tarefa);
        return Ok(updatedTarefa);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _tarefaService.DeleteAsync(id);
        return NoContent();
    }
}
