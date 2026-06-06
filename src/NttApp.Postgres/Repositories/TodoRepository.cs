using Microsoft.EntityFrameworkCore;
using NttApp.Domain.Todos.Entities;
using NttApp.Domain.Todos.Repositories;
using NttApp.Postgres.Data;

namespace NttApp.Postgres.Repositories;

public class TodoRepository(
    IDbContextFactory<PostgresDbContext> dbContextFactory) 
    : PostgresRepository<Todo, long>(dbContextFactory), ITodoRepository
{
    
}