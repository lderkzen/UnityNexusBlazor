namespace UnityNexus.Server.Shared.Stores
{
    public interface IAppConfigurationStore
    {
        /// <summary>
        /// Loads all entries of the app configuration from the database.
        /// </summary>
        /// <returns>A <see cref="Dictionary{TKey,TValue}"/> with each key-value pair.</returns>
        Task<Dictionary<string, string?>> LoadEntriesAsync();

        /// <summary>
        /// Updates the database with the given <paramref name="entries"/>.
        /// </summary>
        /// <param name="entries">The entries containing the new values.</param>
        /// <returns>Any exception that might have been thrown while updating.</returns>
        Task<Exception?> UpdateEntriesAsync(IReadOnlyDictionary<string, string?> entries);
    }
}
