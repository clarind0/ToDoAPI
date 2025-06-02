using IFCE.TodoList.Application.Interfaces;
using IFCE.TodoList.Domain.Repositories;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace IFCE.TodoList.Application.Services;

public class UsuarioService : IUsuarioInterface
{
    private readonly ApplicationDbContext _context;

    public UsuarioService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Response<List<Usuario>>> ListarUsuarios()
    {
        Response<List<Usuario>> resposta = new Response<List<Usuario>>();
        try
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            
            resposta.Dados = usuarios;
            resposta.Mensagem = "Todos os usuarios foram coletados com sucesso!";
            
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<Usuario>> BuscarUsuarioPorId(int idUsuario)
    {
        Response<Usuario> resposta = new Response<Usuario>();
        try
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == idUsuario);

            if (usuario == null)
            {
                resposta.Mensagem = "Nenhum registro localizado!";
                return resposta;
            }
            
            resposta.Dados = usuario;
            resposta.Mensagem = "Usuário localizado com sucesso!";
            
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<Usuario>> BuscarUsuarioPorIdTodoList(int idTodoList)
    {
        Response<Usuario> resposta = new Response<Usuario>();
        try
        {
            var todoList = await _context.TodoLists
                .Include(a => a.Usuario).FirstOrDefaultAsync(todoListBanco => todoListBanco.Id == idTodoList);

            if (todoList == null)
            {
                resposta.Mensagem = "Nenhum usuario localizado!";
                return resposta;
            }

            resposta.Dados = todoList.Usuario;
            resposta.Mensagem = "Usuario localizado com sucesso!";
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
}