namespace IFCE.TodoList.Application.DTO;

public class CreateTarefaDto
{
    public string Descricao { get; set; } = String.Empty;
    public Domain.Entities.TodoList TodoList { get; set; }
}