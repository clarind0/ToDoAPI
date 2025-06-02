using IFCE.TodoList.Application.Interfaces;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Infra.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IFCE.TodoList.API.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioInterface _usuarioInterface;
    public UsuarioController(IUsuarioInterface usuarioInterface)
    {
        _usuarioInterface = usuarioInterface;
    }
    
    [HttpGet("ListarUsuarios")]
    public async Task<ActionResult<Response<List<Usuario>>>> ListarUsuarios()
    {
        var usuarios = await _usuarioInterface.ListarUsuarios();
        
        return Ok(usuarios);
    }
    
    [HttpGet("BuscarUsuarioPorId/{idUsuario}")]
    public async Task<ActionResult<Response<Usuario>>> BuscarUsuarioPorId(int idUsuario)
    {
        var usuario = await _usuarioInterface.BuscarUsuarioPorId(idUsuario);
        
        return Ok(usuario);
    }
    
    [HttpGet("BuscarUsuarioPorIdTodoList/{idTodoList}")]
    public async Task<ActionResult<Response<Usuario>>> BuscarUsuarioPorIdTodoList(int idTodoList)
    {
        var usuario = await _usuarioInterface.BuscarUsuarioPorIdTodoList(idTodoList);
        
        return Ok(usuario);
    }
}