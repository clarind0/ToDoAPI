using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFCE.TodoList.Infra.Data.Mappings;

public class TodoListMapping : IEntityTypeConfiguration<Domain.Entities.TodoList>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.TodoList> builder)
    {
        builder.HasKey(l => l.Id);
        
        builder.Property(l => l.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(l => l.CreatedAt)
            .HasDefaultValue(DateTime.Now);

        builder.Property(l => l.UpdatedAt)
            .HasDefaultValue(DateTime.Now);

        builder.HasOne(l => l.Usuario)
            .WithMany(u => u.TodoLists)
            .HasForeignKey(l => l.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}