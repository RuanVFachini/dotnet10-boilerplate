using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NttApp.Domain.Todos.Entities;

namespace NttApp.Postgres.Data.Configurations.Todos;

public class TodoPgConfiguration : IPgConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("tb_todos");
    }
}