using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using NttApp.Api.Web.Requests;
using NttApp.Api.Web.Responses;
using NttApp.Domain.Todos.Entities;
using NttApp.Domain.Todos.Services.Interfaces;

namespace NttApp.Api.Web.Routes.Todos;

internal class TodoAppRouter : IAppRouter
{
    public void RegisterHandlers(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/todos", (
            [FromServices] ITodoService service,
            [FromServices] IMapper mapper) =>
        {
            var responses = mapper.Map<IList<TodoResponse>>(service.GetList());
            return Results.Ok(responses);
        });

        endpoints.MapPost("/todos", (
            [FromBody] TodoRequest request,
            [FromServices] ITodoService service,
            [FromServices] IMapper mapper) =>
        {
            var entity = service.Create(mapper.Map<Todo>(request));
            var responses = mapper.Map<TodoResponse>(entity);
            return Results.Created($"/todos/{responses.Id}", responses);
        });
    }
}