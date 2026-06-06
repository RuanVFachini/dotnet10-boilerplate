namespace NttApp.Domain.Commons.Entities;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}

public interface IAuditedEntity<TKey> :  IEntity<TKey>
{
    public DateTime CretedAt { get; set; }
    
    public Guid CreatedBy { get; set; }
}

public interface IFullAuditedEntity<TKey> : IAuditedEntity<TKey>
{
    public DateTime UpdatedAt { get; set; }
    
    public Guid UpdatedBy { get; set; }
}