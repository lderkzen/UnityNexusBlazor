namespace HandOfUnity.Generic.Cache.Interfaces
{
    public interface IReadOnlyCache<TModel> where TModel : class
    {
        /// <summary>
        /// Get all cached models
        /// </summary>
        public Task<IReadOnlyCollection<TModel>> GetAllAsync();
    }
}
