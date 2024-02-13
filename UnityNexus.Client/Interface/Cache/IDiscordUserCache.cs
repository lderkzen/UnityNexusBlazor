using System.Security.Claims;
using UnityNexus.Shared.Entities;

namespace UnityNexus.Client.Interface.Cache
{
    public interface IDiscordUserCache
    {
        public Task<NexusUser> GetUserAsync(ClaimsPrincipal claimsPrincipal);

        public Task<NexusUser> GetUserAsync(int userId);

        public Task<IReadOnlyCollection<NexusUser>> GetUsersAsync(IEnumerable<int> userIds);
    }
}
