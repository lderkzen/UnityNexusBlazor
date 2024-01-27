namespace HandOfUnity.Database.Interfaces
{
    public interface IEntityManager<TContext, TEntity, TKey> : IEntityRepository<TContext, TEntity, TKey>
        where TContext : DbContext
        where TEntity : IEntity, new()
    {
        public Task InsertAsync(TEntity entity);

        public Task InsertRangeAsync(IEnumerable<TEntity> entities);

        public Task UpdateAsync(TEntity entity);

        public Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        public Task InsertOrUpdateAsync(TEntity entity);

        public Task InserOrUpdateRangeAsync(IEnumerable<TEntity> entities);

        public Task DeleteAsync(TEntity entity);

        public Task DeleteAsync(TKey key);

        public Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        public Task DeleteRangeAsync(IEnumerable<TKey> keys);
    }
}
