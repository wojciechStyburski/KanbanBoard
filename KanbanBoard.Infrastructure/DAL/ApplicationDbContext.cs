using KanbanBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KanbanBoard.Infrastructure.DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}