using NttApp.Domain.Todos.Entities;
using NttApp.Domain.Todos.Repositories;
using NttApp.Domain.Todos.Services.Interfaces;

namespace NttApp.Domain.Todos.Services;

public class TodoService(
    ITodoRepository repository) : ITodoService
{
    public IList<Todo> GetList() => repository.GetAll().ToList();
    public Todo Create(Todo entity)
    {
        return repository.Add(entity);
    }
}