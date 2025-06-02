using System.Security.Claims;
using IFCE.TodoList.Application.DTO;
using IFCE.TodoList.Application.Interfaces;
using IFCE.TodoList.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFCE.TodoList.API.Controllers;

[Authorize]
[ApiController]
[Route("api/tarefa")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaInterface _tarefaInterface;

    public TarefaController(ITarefaInterface tarefaInterface)
    {
        _tarefaInterface = tarefaInterface;
    }
    
    [HttpGet("ListarTarefas")]
    public async Task<ActionResult<Response<List<Tarefa>>>> ListarTarefas()
    {
        var tarefas = await _tarefaInterface.ListarTarefas();
        
        return Ok(tarefas);
    }
    
    [HttpGet("BuscarTarefaPorId/{idTarefa}")]
    public async Task<ActionResult<Response<Tarefa>>> BuscarTarefaPorId(int idTarefa)
    {
        var tarefa = await _tarefaInterface.BuscarTarefaPorId(idTarefa);
        
        return Ok(tarefa);
    }
    
    [HttpGet("BuscarTarefaPorIdTodoList/{idTodoList}")]
    public async Task<ActionResult<Response<Tarefa>>> BuscarTarefaPorIdTodoList(int idTodoList)
    {
        var tarefa = await _tarefaInterface.BuscarTarefaPorIdTodoList(idTodoList);
        
        return Ok(tarefa);
    }
    
    [HttpPut("AtualizarTarefa")]
    public async Task<ActionResult<Response<List<Tarefa>>>> AtualizarTarefa(EditTarefaDto editTarefaDto)
    {
        var tarefas = await _tarefaInterface.AtualizarTarefa(editTarefaDto);
        return Ok(tarefas);
    }
    
    [HttpDelete("DeletarTarefa/{idTarefa}")]
    public async Task<ActionResult<Response<List<Tarefa>>>> DeletarTarefa(int idTarefa)
    {
        var tarefas = await _tarefaInterface.DeletarTarefa(idTarefa);
        return Ok(tarefas);
    }
}