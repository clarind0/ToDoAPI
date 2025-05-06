using System.Reflection;
using IFCE.TodoList.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IFCE.TodoList.Infra.Data.Contexts;

public class ApplicationDbContext :  DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    private readonly string _connectionString = "Server=localhost;Database=TodoList;User Id=sa;Password=<PASSWORD>;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }

    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Tarefa> Tarefas { get; set; } = null!;
    public DbSet<Domain.Entities.TodoList> TodoLists { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}