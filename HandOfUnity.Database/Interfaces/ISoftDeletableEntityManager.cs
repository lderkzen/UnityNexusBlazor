namespace HandOfUnity.Database.Interfaces
{
    public interface ISoftDeletableEntityManager<TContext, TEntity, TKey> : IEntityManager<TContext, TEntity, TKey>
        where TContext : DbContext
        where TEntity : IEntity, ISoftDeletableEntity, new()
    {
        public Task DestroyAsync(TEntity entity);

        public Task DestroyAsync(TKey key);

        public Task DestroyRangeAsync(IEnumerable<TEntity> entities);

        public Task DestroyRangeAsync(IEnumerable<TKey> keys);

        public Task PurgeAsync<TPurgeEntity>();
    }
}
