using NttApp.Domain.Commons.Interfaces;
using NttApp.Domain.Todos.Entities;

namespace NttApp.Domain.Todos.Repositories;

public interface ITodoRepository : IRepository<Todo, long>
{
    
}