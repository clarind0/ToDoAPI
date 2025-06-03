using System.Text.Json.Serialization;

namespace IFCE.TodoList.Domain.Entities;

public class Tarefa
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int? IdTodoList { get; set; }
    public TodoList? TodoList { get; set; }
    [JsonIgnore]
    
    public bool Concluded { get; set; } =  false;
    public DateTime? ConcludedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}