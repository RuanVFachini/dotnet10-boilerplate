using Microsoft.EntityFrameworkCore;
using NttApp.Postgres.Data.Configurations;

namespace NttApp.Postgres.Data;

public class PostgresDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(PostgresDbContext).Assembly, 
            type => type.GetInterface(nameof(IPgConfiguration<> )) != null);
    }
}