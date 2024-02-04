using System.Security.Claims;
using UnityNexus.Shared.Entities;

namespace UnityNexus.Client.Interface.Cache
{
    public interface IDiscordUserCache
    {
        public Task<DiscordUser> GetUserAsync(ClaimsPrincipal claimsPrincipal);

        public Task<DiscordUser> GetUserAsync(int userId);

        public Task<IReadOnlyCollection<DiscordUser>> GetUsersAsync(IEnumerable<int> userIds);
    }
}
