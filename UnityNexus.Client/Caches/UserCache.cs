using System.Security.Claims;

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

        private async Task<UserModel> InternalGetUserAsync(Guid userId)
        {
            UserModel? cachedModel;
            if ((cachedModel = TryGetUserModelFromCache(userId)) is not null)
                return cachedModel;

            throw new NotImplementedException();
        }

        private UserModel? TryGetUserModelFromCache(Guid userId)
        {
            return _cache.TryGetValue(userId, out var cached) && !ShouldRefreshCachedItem(cached.LastFetch)
                ? cached.Model
                : null;
        }

        public Task<IReadOnlyCollection<UserModel>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<UserModel>> GetUsersByIdsAsync(IEnumerable<Guid> userIds)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
