using NttApp.Domain.Commons.Entities;

namespace NttApp.Domain.Todos.Entities;

public class Todo : IEntity<long>
{
    public long Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public bool IsComplete { get; set; }

    public Todo(long id, string title, string description, bool isComplete)
    {
        Id = id;
        Title = title;
        Description = description;
        IsComplete = isComplete;
    }

    public Todo()
    {
    }
}