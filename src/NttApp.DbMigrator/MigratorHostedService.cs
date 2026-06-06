using Microsoft.EntityFrameworkCore;
using NttApp.DbMigrator.Data;

namespace NttApp.DbMigrator;

public class MigratorHostedService(
    IServiceProvider serviceProvider
    ) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        serviceProvider.GetService<MigratorDbContext>()?.Database.MigrateAsync(stoppingToken);
        
        return Task.CompletedTask;
    }
}