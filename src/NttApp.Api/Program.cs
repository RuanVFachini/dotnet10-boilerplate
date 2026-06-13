using Mapster;
using Microsoft.EntityFrameworkCore;
using NttApp.Api.Web.Routes.Extensions;
using NttApp.Domain.Extensions;
using NttApp.OpenTelemetry.Extensions;
using NttApp.Postgres.Data;

namespace NttApp.Api;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var applicationName = builder.Configuration["ApplicationName"] ?? "no-app-name";
        
        builder.Services.AddOpenTelemetry(applicationName);
        builder.Services.AddPooledDbContextFactory<PostgresDbContext>((_ , options) => 
                options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

        builder.UseOpenTelemetry(applicationName);
        
        // InMemoryDb.Extesions.ServiceCollectionExtensions.RegisterRepositories(builder.Services)
        Postgres.Extesions.ServiceCollectionExtensions.RegisterRepositories(builder.Services)
            .RegisterServices()
            .AddMapster();

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi("ntt-app");

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi("/openapi/{documentName}.yaml");
        }

        app.UseHttpsRedirection(); 

        app.RegisterApiRoutes();

        app.Run();
    }
    
}