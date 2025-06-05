using System.Text.Json.Serialization;

namespace IFCE.TodoList.Domain.Entities;

public class TodoList
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public ICollection<Tarefa>? Tarefas { get; set; }
    
    public DateTime? Deadline { get; set; }
    
    public DateTime CreatedAt { get; set; } =  DateTime.UtcNow; 
    public DateTime UpdatedAt { get; set; } =  DateTime.UtcNow;
}