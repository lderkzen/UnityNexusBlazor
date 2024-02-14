namespace UnityNexus.Client.Caches
{
    public class UserCache : IUserCache
    {
        private readonly ConcurrentDictionary<Guid, (UserModel Model, DateTime LastFetch)> _cache;

        public UserCache(

        )
        {
            _cache = [];
        }

        private static bool ShouldRefreshCachedItem(DateTime lastFetch) => (DateTime.UtcNow - lastFetch).TotalMinutes >= 15;
    }
}
