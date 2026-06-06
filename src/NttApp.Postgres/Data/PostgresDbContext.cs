using Microsoft.EntityFrameworkCore;
using NttApp.Domain.Todos.Entities;
using NttApp.Postgres.Data.Configurations;

namespace NttApp.Postgres.Data;

public class PostgresDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Todo>  Todos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(PostgresDbContext).Assembly,
            type => typeof(IPgConfiguration<Todo>).IsAssignableFrom(type));
    }
}