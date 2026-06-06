using NttApp.Domain.Todos.Entities;
using NttApp.Domain.Todos.Repositories;

namespace NttApp.InMemoryDb.Repositories;

public class TodoRepository : InMemoryRepository<Todo, long>, ITodoRepository
{
    
}