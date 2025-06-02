using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Application.Interfaces;

public interface IUsuarioInterface
{
    Task<Response<List<Usuario>>> ListarUsuarios();
    Task<Response<Usuario>> BuscarUsuarioPorId(int idUsuario);
    Task<Response<Usuario>> BuscarUsuarioPorIdTodoList(int idTodoList);
}