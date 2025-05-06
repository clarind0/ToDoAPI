namespace IFCE.TodoList.Domain.Entities;

public class Tarefa
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Descricao { get; set; } = string.Empty;
    
    public Guid  UserId { get; set; }
    public Usuario User { get; set; } =  null!;
    
    public Guid? AssignmentListId { get; set; }
    public TodoList? AssignmentList { get; set; }
    
    public bool Concluded { get; set; } =  false;
    public DateTime? ConcludedAt { get; set; }
    public DateTime? Deadline { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}