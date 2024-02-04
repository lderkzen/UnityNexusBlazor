using System.Security.Claims;

namespace UnityNexus.Client.BLL.Cache
{
    public class DiscordUserCache : IDiscordUserCache
    {
        private readonly ConcurrentDictionary<int, (DiscordUser user, DateTime LastFetch)> _cache;

        public DiscordUserCache()
        {
            _cache = [];
        }

        private static bool ShouldRefreshCachedItem(DateTime lastFetch) => (DateTime.UtcNow - lastFetch).TotalMinutes >= 15;

        public Task<DiscordUser> GetUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }

        public Task<DiscordUser> GetUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<DiscordUser>> GetUsersAsync(IEnumerable<int> userIds)
        {
            throw new NotImplementedException();
        }
    }
}
