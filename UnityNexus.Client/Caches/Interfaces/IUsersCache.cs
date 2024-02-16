namespace UnityNexus.Client.Caches.Interfaces
{
    public interface IUserCache
    {
        public Task<IReadOnlyCollection<UserModel>> GetAllUsersAsync();
        public Task<IReadOnlyCollection<UserModel>> GetUsersByIdsAsync(IEnumerable<Guid> userIds);
        public Task<UserModel> GetUserAsync(ClaimsPrincipal claimsPrincipal);
        public Task<UserModel> GetUserAsync(Guid userId);
    }
}
