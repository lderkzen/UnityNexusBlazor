namespace UnityNexus.Server.Shared.Stores
{
    public interface IRemoteUserStore
    {
        public Task<List<Guid>?> GetAllUserIdsAsync();
        public Task<UserModel?> GetUserModelByIdAsync(int userId);
    }
}
