using NttApp.Domain.Commons.Entities;
using NttApp.Domain.Todos.Entities;

namespace NttApp.Domain.Commons.Interfaces;

public interface IRepository<TEntity, in TKey> 
    where TEntity : IEntity<TKey>
{
    public TEntity Add(TEntity entity);
    public void Remove(TEntity entity);
    public void Update(TEntity entity);
    public TEntity? Get(TKey id);
    public IQueryable<TEntity> GetAll();
}