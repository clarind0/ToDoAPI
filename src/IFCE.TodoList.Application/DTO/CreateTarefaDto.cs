namespace IFCE.TodoList.Application.DTO;

public class CreateTarefaDto
{
    public string Descricao { get; set; } = String.Empty;
    public int? IdTodoList { get; set; }
}