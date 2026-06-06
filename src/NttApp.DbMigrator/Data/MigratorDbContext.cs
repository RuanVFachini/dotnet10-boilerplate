using Microsoft.EntityFrameworkCore;
using NttApp.Postgres.Data;

namespace NttApp.DbMigrator.Data;

public class MigratorDbContext(DbContextOptions options) : PostgresDbContext(options)
{
    
}