using Microsoft.Extensions.DependencyInjection;
using NttApp.Domain.Todos.Repositories;
using NttApp.Postgres.Repositories;

namespace NttApp.Postgres.Extesions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterRepositories(
        this IServiceCollection services)
    {
        services.AddTransient<ITodoRepository, TodoRepository>();
        
        return services;
    }
}