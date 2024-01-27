namespace HandOfUnity.Database
{
    public abstract class EntityManager<TContext, TEntity, TKey> : EntityRepository<TContext, TEntity, TKey>, IEntityManager<TContext, TEntity, TKey>
        where TContext : DbContext
        where TEntity : IEntity, new()
    {
        protected EntityManager(TContext context) : base(context)
        {
        }

        public abstract Task DeleteAsync(TEntity entity);
        public abstract Task DeleteAsync(TKey key);
        public abstract Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        public abstract Task DeleteRangeAsync(IEnumerable<TKey> keys);
        public abstract Task InserOrUpdateRangeAsync(IEnumerable<TEntity> entities);
        public abstract Task InsertAsync(TEntity entity);
        public abstract Task InsertOrUpdateAsync(TEntity entity);
        public abstract Task InsertRangeAsync(IEnumerable<TEntity> entities);
        public abstract Task UpdateAsync(TEntity entity);
        public abstract Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}
