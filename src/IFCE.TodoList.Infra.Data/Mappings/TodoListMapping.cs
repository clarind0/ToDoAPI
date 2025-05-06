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
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(l => l.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(l => l.User)
            .WithMany(u => u.TodoLists)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}