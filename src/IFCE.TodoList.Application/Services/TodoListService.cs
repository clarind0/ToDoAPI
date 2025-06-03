using IFCE.TodoList.Application.DTO;
using IFCE.TodoList.Application.Interfaces;
using IFCE.TodoList.Domain.Repositories;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;


namespace IFCE.TodoList.Application.Services;

public class TodoListService : ITodoListInterface
{
    private readonly ApplicationDbContext _context;

    public TodoListService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Response<List<Domain.Entities.TodoList>>> ListarTodoLists()
    {
        Response<List<Domain.Entities.TodoList>> resposta = new Response<List<Domain.Entities.TodoList>>();
        try
        {
            var todoList = await _context.TodoLists.ToListAsync();
            
            resposta.Dados = todoList;
            resposta.Mensagem = "Todos os to do's foram coletados com sucesso!";
            
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<Domain.Entities.TodoList>> BuscarTodoListPorId(int idTodoList)
    {
        Response<Domain.Entities.TodoList> resposta = new Response<Domain.Entities.TodoList>();
        try
        {
            var todoList = await _context.TodoLists.FirstOrDefaultAsync(todoListBanco => todoListBanco.Id == idTodoList);

            if (todoList == null)
            {
                resposta.Mensagem = "Nenhum registro localizado!";
                return resposta;
            }
            
            resposta.Dados = todoList;
            resposta.Mensagem = "To do localizado com sucesso!";
            
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<Domain.Entities.TodoList>> BuscarTodoListPorIdUsuario(int idUsuario)
    {
        Response<Domain.Entities.TodoList> resposta = new Response<Domain.Entities.TodoList>();
        try
        {
            var usuario = await _context.Usuarios
                .Include(a => a.TodoLists).
                FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Id == idUsuario);

            if (usuario == null)
            {
                resposta.Mensagem = "Nenhum registro localizado!";
                return resposta;
            }

            resposta.Dados = usuario.TodoLists.FirstOrDefault();;
            resposta.Mensagem = "To do localizado com sucesso!";
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<List<Domain.Entities.TodoList>>> CriarTodoList(CreateTodoListDto createTodoListDto)
    {
        Response<List<Domain.Entities.TodoList>> resposta = new Response<List<Domain.Entities.TodoList>>();

        try
        {
            var todolist = new Domain.Entities.TodoList()
            {
                Nome = createTodoListDto.Nome,
                IdUsuario = createTodoListDto.IdUsuario,
                Deadline = createTodoListDto.Deadline,
                Tarefas = createTodoListDto.Tarefas
            };

            _context.Add(todolist);
            await _context.SaveChangesAsync();
            
            resposta.Dados = await _context.TodoLists.ToListAsync();
            resposta.Mensagem = "To do criado com sucesso!";
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<List<Domain.Entities.TodoList>>> AtualizarTodoList(EditTodoListDto editTodoListDto)
    {
        Response<List<Domain.Entities.TodoList>> resposta = new Response<List<Domain.Entities.TodoList>>();
        
        try
        {
            var todoList = await _context.TodoLists
                .FirstOrDefaultAsync(todoListBanco => todoListBanco.Id == editTodoListDto.Id);

            if (todoList == null)
            {
                resposta.Mensagem = "Nenhum to do localizado!";
                resposta.Status = false;
            }
            
            todoList.Nome = editTodoListDto.Nome;
            todoList.IdUsuario = editTodoListDto.IdUsuario;
            todoList.Deadline = editTodoListDto.Deadline;
            todoList.Tarefas = editTodoListDto.Tarefas;

            _context.Update(todoList);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.TodoLists.ToListAsync();
            resposta.Mensagem = "To do atualizado com sucesso!";
            
            return resposta;
            
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<List<Domain.Entities.TodoList>>> DeletarTodoList(int idTodoList)
    {
        Response<List<Domain.Entities.TodoList>> resposta = new Response<List<Domain.Entities.TodoList>>();

        try
        {
            var todoList = await _context.TodoLists
                .FirstOrDefaultAsync(todoListBanco => todoListBanco.Id == idTodoList);

            if (todoList == null)
            {
                resposta.Mensagem = "Nenhum to do localizado!";
                resposta.Status = false;
            }

            _context.Remove(todoList);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.TodoLists.ToListAsync();
            resposta.Mensagem = "To do deletado com sucesso!";
            
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