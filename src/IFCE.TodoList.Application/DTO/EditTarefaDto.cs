namespace IFCE.TodoList.Application.DTO;

public class EditTarefaDto
{
    public int Id { get; set; }
    public string Descricao { get; set; } = String.Empty;
    public int? IdTodoList { get; set; }
    public Domain.Entities.TodoList? TodoList { get; set; }
    public bool Concluded { get; set; } =  false;
    public DateTime? ConcludedAt { get; set; }
}