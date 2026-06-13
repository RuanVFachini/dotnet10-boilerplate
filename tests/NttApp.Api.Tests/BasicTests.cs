using System.Data.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using NttApp.Postgres.Data;

namespace NttApp.Api.Tests;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == 
                     typeof(IDbContextOptionsConfiguration<PostgresDbContext>));

            services.Remove(dbContextDescriptor);

            var dbConnectionDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbConnection));

            services.Remove(dbConnectionDescriptor);
            
            NttApp.InMemoryDb.Extesions.ServiceCollectionExtensions.RegisterRepositories(services);
        });
    }
}

public class BasicTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    [Fact]
    public async Task Test1()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("http://localhost:8080/todos");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        // Assert.Equal("text/html; charset=utf-8", 
        //     response.Content.Headers.ContentType.ToString());
    }
}