using NttApp.Domain.Todos.Entities;

namespace NttApp.Domain.Todos.Services.Interfaces;

public interface ITodoService
{
    IList<Todo> GetList();
    Todo Create(Todo map);
}