using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Application.DTO;

public class CreateTodoListDto
{
    public string Nome { get; set; } = null!;
    public int IdUsuario { get; set; }
    public string Descricao { get; set; } = null!;
    public DateTime? Deadline { get; set; }
}