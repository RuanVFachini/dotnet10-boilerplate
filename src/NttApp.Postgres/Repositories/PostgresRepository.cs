using Microsoft.EntityFrameworkCore;
using NttApp.Domain.Commons.Entities;
using NttApp.Domain.Commons.Interfaces;
using NttApp.Postgres.Data;

namespace NttApp.Postgres.Repositories;

public abstract class PostgresRepository<TEntity, TKey>(
        IDbContextFactory<PostgresDbContext> dbContextFactory
    ) : 
    IRepository<TEntity, TKey>, IAsyncDisposable
    where TEntity : class, IEntity<TKey>
{
    private PostgresDbContext DbContext
    {
        get => field ??= dbContextFactory.CreateDbContext();
    } = null;

    protected virtual DbSet<TEntity> DbSet => DbContext.Set<TEntity>();

    public virtual TEntity Add(TEntity entity)
    {
        DbSet.Add(entity);
        return entity;
    }
    
    public virtual void Remove(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public virtual void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public virtual TEntity? Get(TKey id)
    {
        return DbSet.FirstOrDefault(x => x.Id!.Equals(id));
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        return DbSet.AsQueryable();
    }

    public async ValueTask DisposeAsync()
    {
        await DbContext.DisposeAsync();
    }
}