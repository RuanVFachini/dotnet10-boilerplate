using Microsoft.EntityFrameworkCore;

namespace NttApp.Postgres.Data.Configurations;

public interface IPgConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class
{
    
}