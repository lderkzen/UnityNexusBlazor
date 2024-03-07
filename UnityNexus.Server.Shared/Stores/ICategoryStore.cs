namespace UnityNexus.Server.Shared.Stores
{
    public interface ICategoryStore
    {
        public Task<Category> GetCategoryByIdAsync(CategoryId categoryId, bool tracking = false);
        public Task<List<Category>> GetAllCategoriesAsync(bool tracking = false);

        public void CreateCategory(Category category);
        public Task<(Dictionary<string, (string OldValue, string NewValue)>? Changes, Exception? Exception)> UpdateCategoryAsync(
            Category dbEntity,
            Category requestEntity
        );
        public Task<Exception?> DeleteCategoryAsync(Category category);
        public Task<Exception?> SaveChangesAsync();
    }
}
