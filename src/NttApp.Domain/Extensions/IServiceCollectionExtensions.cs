using Microsoft.Extensions.DependencyInjection;
using NttApp.Domain.Todos.Services;
using NttApp.Domain.Todos.Services.Interfaces;

namespace NttApp.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        return services;
    }
}