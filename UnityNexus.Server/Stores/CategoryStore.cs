namespace UnityNexus.Server.Stores
{
    public class CategoryStore : ICategoryStore
    {
        private readonly UnityNexusContext _unityNexusContext;

        public CategoryStore(UnityNexusContext unityNexusContext)
        {
            _unityNexusContext = unityNexusContext;
        }

        private IQueryable<Category> GetBaseQueryable(bool tracking)
        {
            IQueryable<Category> query = _unityNexusContext
                .Categories
                .OrderBy(c => c.CategoryId)
                .AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public async Task<Category> GetCategoryByIdAsync(CategoryId categoryId, bool tracking = false)
        {
            return await GetBaseQueryable(tracking).FirstAsync(m => m.CategoryId == categoryId);
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool tracking = false)
        {
            return await GetBaseQueryable(tracking).ToListAsync();
        }

        public void CreateCategory(Category category)
        {
            category.CategoryId = null!;
            _unityNexusContext.Categories.Add(category);
        }

        public Task<(Dictionary<string, (string OldValue, string NewValue)>? Changes, Exception? Exception)> UpdateCategoryAsync(
            Category dbEntity,
            Category requestEntity
        )
        {
            throw new NotImplementedException();
        }

        public async Task<Exception?> DeleteCategoryAsync(Category category)
        {
            try
            {
                _unityNexusContext.Categories.Remove(category);
                await _unityNexusContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return e;
            }

            return null;
        }

        public async Task<Exception?> SaveChangesAsync()
        {
            try
            {
                await _unityNexusContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return e;
            }

            return null;
        }
    }
}
