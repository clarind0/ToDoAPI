using IFCE.TodoList.Application.DTO;
using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Application.Interfaces;

public interface ITodoListInterface
{
    Task<Response<List<Domain.Entities.TodoList>>> ListarTodoLists();
    Task<Response<Domain.Entities.TodoList>> BuscarTodoListPorId(int idTodoList);
    Task<Response<Domain.Entities.TodoList>> BuscarTodoListPorIdUsuario(int idUsuario);
    Task<Response<List<Domain.Entities.TodoList>>> CriarTodoList(CreateTodoListDto createTodoListDto);         
    Task<Response<List<Domain.Entities.TodoList>>> AtualizarTodoList(int idTodoList, EditTodoListDto editTodoListDto);
    Task<Response<List<Domain.Entities.TodoList>>> DeletarTodoList(int idTodoList);
}   