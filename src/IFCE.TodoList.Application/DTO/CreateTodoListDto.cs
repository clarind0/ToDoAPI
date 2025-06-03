using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Application.DTO;

public class CreateTodoListDto
{
    public string Nome { get; set; } = null!;
    public int IdUsuario { get; set; }
    public DateTime? Deadline { get; set; }
    public List<Tarefa>? Tarefas { get; set; } = null!;
}