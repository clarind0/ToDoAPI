using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Application.DTO;

public class EditTodoListDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime? Deadline { get; set; }
    public List<Tarefa> Tarefas { get; set; } = null!;
}