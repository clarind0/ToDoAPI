using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Application.DTO;

public class EditTodoListDto
{ 
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public int IdUsuario { get; set; }
    public DateTime? Deadline { get; set; }
    
}