namespace UnityNexus.Shared.Stores
{
    public interface IRemoteUserStore
    {
        public Task<List<int>> GetAllUserIdsAsync();
        public Task<NexusUser> GetUserModelByIdAsync(int userId);
    }
}
