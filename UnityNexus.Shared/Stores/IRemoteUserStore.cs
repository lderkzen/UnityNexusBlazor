namespace UnityNexus.Shared.Stores
{
    public interface IRemoteUserStore
    {
        public Task<List<int>> GetAllUserIdsAsync();
        public Task<UserModel> GetUserModelByIdAsync(int userId);
    }
}
