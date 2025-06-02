using System.Linq.Expressions;
using IFCE.TodoList.Application.DTO;
using IFCE.TodoList.Application.Interfaces;
using IFCE.TodoList.Domain.Repositories;
using IFCE.TodoList.Domain.Entities;
using IFCE.TodoList.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;


namespace IFCE.TodoList.Application.Services;

public class TarefaService : ITarefaInterface
{
    private readonly ApplicationDbContext _context;

    public TarefaService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Response<List<Tarefa>>> ListarTarefas()
    {
        Response<List<Tarefa>> resposta = new Response<List<Tarefa>>();
        try
        {
            var tarefa = await _context.Tarefas.ToListAsync();
            
            resposta.Dados = tarefa;
            resposta.Mensagem = "Todos as tarefas foram coletadas com sucesso!";
            
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<Tarefa>> BuscarTarefaPorId(int idTarefa)
    {
        Response<Tarefa> resposta = new Response<Tarefa>();
        try
        {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(tarefaBanco => tarefaBanco.Id == idTarefa);

            if (tarefa == null)
            {
                resposta.Mensagem = "Nenhum registro localizado!";
                return resposta;
            }
            
            resposta.Dados = tarefa;
            resposta.Mensagem = "Tarefa localizada com sucesso!";
            
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<Tarefa>> BuscarTarefaPorIdTodoList(int idTodoList)
    {
        Response<Tarefa> resposta = new Response<Tarefa>();
        try
        {
            var todoList = await _context.TodoLists
                .Include(a => a.Tarefas)
                .FirstOrDefaultAsync(todoListBanco => todoListBanco.Id == idTodoList);

            if (todoList == null)
            {
                resposta.Mensagem = "Nenhum registro localizado!";
                return resposta;
            }

            resposta.Dados = todoList.Tarefas.FirstOrDefault();
            resposta.Mensagem = "Tarefa localizada com sucesso!";
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<Response<List<Tarefa>>> CriarTarefa(CreateTarefaDto createTarefaDto)
    {
        Response<List<Tarefa>> resposta = new Response<List<Tarefa>>();

        try
        {
            var tarefa = new Tarefa()
            {
                Descricao = createTarefaDto.Descricao,
                TodoList = createTarefaDto.TodoList
            };

            _context.Add(tarefa);
            await _context.SaveChangesAsync();
            
            resposta.Dados = await _context.Tarefas.ToListAsync();
            resposta.Mensagem = "Tarefa criada com sucesso!";
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
    
    public async Task<Response<List<Tarefa>>> AtualizarTarefa(EditTarefaDto editTarefaDto)
    {
        Response<List<Tarefa>> resposta = new Response<List<Tarefa>>();
        
        try
        {
            var tarefa = await _context.Tarefas
                .FirstOrDefaultAsync(tarefaBanco => tarefaBanco.Id == editTarefaDto.Id);

            if (tarefa == null)
            {
                resposta.Mensagem = "Nenhuma tarefa localizada!";
                resposta.Status = false;
            }
            
            tarefa.Descricao = editTarefaDto.Descricao;
            tarefa.TodoList = editTarefaDto.TodoList;
            tarefa.Concluded = editTarefaDto.Concluded;
            tarefa.ConcludedAt = editTarefaDto.ConcludedAt;

            _context.Update(tarefa);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Tarefas.ToListAsync();
            resposta.Mensagem = "Tarefa atualizada com sucesso!";
            
            return resposta;
            
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
    
    public async Task<Response<List<Tarefa>>> DeletarTarefa(int idTarefa)
    {
        Response<List<Tarefa>> resposta = new Response<List<Tarefa>>();

        try
        {
            var tarefa = await _context.Tarefas
                .FirstOrDefaultAsync(tarefaBanco => tarefaBanco.Id == idTarefa);

            if (tarefa == null)
            {
                resposta.Mensagem = "Nenhum to do localizado!";
                resposta.Status = false;
            }

            _context.Remove(tarefa);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Tarefas.ToListAsync();
            resposta.Mensagem = "Tarefa deletada com sucesso!";
            
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