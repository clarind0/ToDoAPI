namespace IFCE.TodoList.Domain.Entities;

public class TodoList
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    
    public Guid UserId { get; set; }
    public Usuario User { get; set; } = null!;
    
    public List<Tarefa> Tasks { get; set; } = new();
    
    public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } =  DateTime.UtcNow;
}