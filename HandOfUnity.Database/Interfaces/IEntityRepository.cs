namespace HandOfUnity.Database.Interfaces
{
    public interface IEntityRepository<TContext, TEntity, TKey>
        where TContext : DbContext
        where TEntity : IEntity, new()
    {
        public IQueryable<TEntity> GetBaseQueryable();

        public Task<List<TEntity>> FindAllAsync();

        public Task<List<TEntity>> FindAsync(IQueryable<TEntity> query);

        public Task<TEntity> FindOrFailAsync(TKey key);

        public Task<TEntity?> FindOrDefaultAsync(TKey key);
    }
}
