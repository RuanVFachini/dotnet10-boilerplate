using Microsoft.AspNetCore.Mvc.Testing;

namespace NttApp.Api.Tests;

public class BasicTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
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