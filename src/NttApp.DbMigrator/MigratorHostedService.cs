using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NttApp.DbMigrator.Data;

namespace NttApp.DbMigrator;

public class MigratorHostedService(MigratorDbContext dbContext) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        dbContext.Database.MigrateAsync(stoppingToken);
        
        return Task.CompletedTask;
    }
}