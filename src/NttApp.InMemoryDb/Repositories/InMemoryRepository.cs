using NttApp.Domain.Commons.Entities;
using NttApp.Domain.Commons.Interfaces;
using NttApp.Domain.Todos.Entities;

namespace NttApp.InMemoryDb.Repositories;

public class InMemoryRepository<TEntity, TKey> : 
    IRepository<TEntity, TKey>
    where TEntity : IEntity<TKey>
{
    protected virtual HashSet<TEntity> Entities { get; } = [];

    public virtual TEntity Add(TEntity entity)
    {
        Entities.Add(entity);
        return entity;
    }
    
    public virtual void Remove(TEntity entity)
    {
        Entities.Remove(entity);
    }

    public virtual void Update(TEntity entity)
    {
        Entities.Remove(entity);
        Entities.Add(entity);
    }

    public virtual TEntity? Get(TKey id)
    {
        return Entities.FirstOrDefault(x => x.Id?.Equals(id) ?? false);
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        return Entities.AsQueryable();
    }
}