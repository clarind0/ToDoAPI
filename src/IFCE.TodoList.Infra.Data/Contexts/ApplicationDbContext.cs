using System.Reflection;
using IFCE.TodoList.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IFCE.TodoList.Infra.Data.Contexts;

public class ApplicationDbContext :  DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    private readonly string _connectionString = "server=localhost;port=3306;database=ifce_todolist;user=root;password=Lab@inf019;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }


    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Domain.Entities.TodoList> TodoLists { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


}