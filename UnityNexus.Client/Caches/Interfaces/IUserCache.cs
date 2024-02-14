using System.Security.Claims;
using UnityNexus.Shared.Models;

namespace UnityNexus.Client.Caches.Interfaces
{
    public interface IUserCache
    {
        public Task<UserModel> GetUserAsync(ClaimsPrincipal claimsPrincipal);
        public Task<UserModel> GetUserAsync(Guid userId);
        public Task<IReadOnlyCollection<UserModel>> GetUsersAsync(IEnumerable<Guid> userIds);
    }
}
