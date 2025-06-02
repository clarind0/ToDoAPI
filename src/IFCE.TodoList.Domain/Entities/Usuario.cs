using System.Text.Json.Serialization;

namespace IFCE.TodoList.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }  
    public string? Password { get; set; }
    [JsonIgnore]
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<TodoList>? TodoLists { get; set; } = new List<TodoList>();
}