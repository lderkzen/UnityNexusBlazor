using System.Security.Claims;

namespace UnityNexus.Client.BLL.Cache
{
    public class DiscordUserCache : IDiscordUserCache
    {
        private readonly ConcurrentDictionary<int, (NexusUser user, DateTime LastFetch)> _cache;

        public DiscordUserCache()
        {
            _cache = [];
        }

        private static bool ShouldRefreshCachedItem(DateTime lastFetch) => (DateTime.UtcNow - lastFetch).TotalMinutes >= 15;

        public Task<NexusUser> GetUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }

        public Task<NexusUser> GetUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<NexusUser>> GetUsersAsync(IEnumerable<int> userIds)
        {
            throw new NotImplementedException();
        }
    }
}
