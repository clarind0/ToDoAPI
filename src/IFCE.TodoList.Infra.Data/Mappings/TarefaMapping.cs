using IFCE.TodoList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFCE.TodoList.Infra.Data.Mappings;

public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Descricao)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(t => t.Concluded)
            .HasDefaultValue(false);

        builder.Property(t => t.CreatedAt)
            .HasDefaultValue(DateTime.Now);

        builder.Property(t => t.UpdatedAt)
            .HasDefaultValue(DateTime.Now);

        builder.HasOne(t => t.TodoList)
            .WithMany(l => l.Tarefas)
            .HasForeignKey(t => t.TodoList)
            .OnDelete(DeleteBehavior.SetNull);
    }
    
}