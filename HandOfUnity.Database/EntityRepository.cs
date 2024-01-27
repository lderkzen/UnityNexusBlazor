namespace HandOfUnity.Database
{
    public abstract class EntityRepository<TContext, TEntity, TKey> : IEntityRepository<TContext, TEntity, TKey>
        where TContext : DbContext
        where TEntity : IEntity, new()
    {
        protected readonly TContext _context;

        public EntityRepository(TContext context) => _context = context;

        public abstract IQueryable<TEntity> GetBaseQueryable();
        public abstract Task<List<TEntity>> FindAllAsync();
        public abstract Task<List<TEntity>> FindAsync(IQueryable<TEntity> query);
        public abstract Task<TEntity?> FindOrDefaultAsync(TKey key);
        public abstract Task<TEntity> FindOrFailAsync(TKey key);
    }
}
