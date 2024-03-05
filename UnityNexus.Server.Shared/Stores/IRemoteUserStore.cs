namespace UnityNexus.Server.Shared.Stores
{
    public interface IRemoteUserStore
    {
        public Task<List<UserId>?> GetAllUserIdsAsync();
        public Task<UserModel?> GetUserModelByIdAsync(int userId);
    }
}
