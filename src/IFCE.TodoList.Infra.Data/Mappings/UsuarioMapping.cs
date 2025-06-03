using IFCE.TodoList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFCE.TodoList.Infra.Data.Mappings;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        builder.Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Password)
            .IsRequired();

        builder.HasMany(u => u.TodoLists)
            .WithOne(l => l.Usuario)
            .HasForeignKey(l => l.IdUsuario);
    }
    
}