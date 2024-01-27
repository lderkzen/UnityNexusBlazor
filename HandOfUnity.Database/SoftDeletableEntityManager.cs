namespace HandOfUnity.Database
{
    public abstract class SoftDeletableEntityManager<TContext, TEntity, TKey> : EntityManager<TContext, TEntity, TKey>, ISoftDeletableEntityManager<TContext, TEntity, TKey>
        where TContext : DbContext
        where TEntity : IEntity, ISoftDeletableEntity, new()
    {
        protected SoftDeletableEntityManager(TContext context) : base(context)
        {
        }

        public abstract Task DestroyAsync(TEntity entity);
        public abstract Task DestroyAsync(TKey key);
        public abstract Task DestroyRangeAsync(IEnumerable<TEntity> entities);
        public abstract Task DestroyRangeAsync(IEnumerable<TKey> keys);
        public abstract Task PurgeAsync<TPurgeEntity>();
    }
}
