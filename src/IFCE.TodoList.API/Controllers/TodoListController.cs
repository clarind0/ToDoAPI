using System.Security.Claims;
using IFCE.TodoList.Application.DTO;
using IFCE.TodoList.Application.Interfaces;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Infra.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFCE.TodoList.API.Controllers;

[Authorize] // Requer autenticação para acessar as rotas
[ApiController]
[Route("api/todolist")]
public class TodoListController : ControllerBase
{
    
    private readonly ITodoListInterface _todoListInterface;
    public TodoListController(ITodoListInterface todoListInterface)
    {
        _todoListInterface = todoListInterface;
    }
    
    [HttpGet("ListarTodoLists")]
    public async Task<ActionResult<Response<List<Domain.Entities.TodoList>>>> ListarTodoLists()
    {
        var todoLists = await _todoListInterface.ListarTodoLists();
        
        return Ok(todoLists);
    }
    
    [HttpGet("BuscarTodoListPorId/{idTodoList}")]
    public async Task<ActionResult<Response<Domain.Entities.TodoList>>> BuscarTodoLIstPorId(int idTodoList)
    {
        var todoList = await _todoListInterface.BuscarTodoListPorId(idTodoList);
        
        return Ok(todoList);
    }
    
    [HttpGet("BuscarTodoListPorIdUsuario/{idUsuario}")]
    public async Task<ActionResult<Response<Domain.Entities.TodoList>>> BuscarTodoListPorIdUsuario(int idUsuario)
    {
        var todoList = await _todoListInterface.BuscarTodoListPorIdUsuario(idUsuario);
        
        return Ok(todoList);
    }
    
    [HttpPost("CriarTodoList")]
    public async Task<ActionResult<Response<List<Domain.Entities.TodoList>>>> CriarTodoList(CreateTodoListDto createTodoListDto)
    {
        var todoLists = await _todoListInterface.CriarTodoList(createTodoListDto);
        
        return Ok(todoLists);
    }

    [HttpPut("AtualizarTodoList")]
    public async Task<ActionResult<Response<List<Domain.Entities.TodoList>>>> AtualizarTodoList(EditTodoListDto editTodoListDto)
    {
        var todoLists = await _todoListInterface.AtualizarTodoList(editTodoListDto);
        return Ok(todoLists);
    }
            
    [HttpDelete("DeletarTodoList/{idTodoList}")]
    public async Task<ActionResult<Response<List<Domain.Entities.TodoList>>>> DeletarTodoList(int idTodoList)
    {
        var todoLists = await _todoListInterface.DeletarTodoList(idTodoList);
        return Ok(todoLists);
    }
}
