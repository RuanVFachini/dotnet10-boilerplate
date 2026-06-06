using Microsoft.EntityFrameworkCore;
using NttApp.DbMigrator;
using NttApp.DbMigrator.Data;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<MigratorDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});

builder.Services.AddHostedService<MigratorHostedService>();

IHost host = builder.Build();
host.Run();