using IFCE.TodoList.Application.DTO;
using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Application.Interfaces;

public interface ITarefaInterface
{
    Task<Response<List<Tarefa>>> ListarTarefas();
    Task<Response<Tarefa>> BuscarTarefaPorId(int idTarefa);
    Task<Response<Tarefa>> BuscarTarefaPorIdTodoList(int idTodoList);
    Task<Response<List<Tarefa>>> CriarTarefa(CreateTarefaDto createTarefaDto);         
    Task<Response<List<Tarefa>>> AtualizarTarefa(int idTarefa, EditTarefaDto editTarefaDto);
    Task<Response<List<Tarefa>>> DeletarTarefa(int idTarefa);
}