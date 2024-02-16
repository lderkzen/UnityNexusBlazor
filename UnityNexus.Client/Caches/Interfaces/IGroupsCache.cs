namespace UnityNexus.Client.Caches.Interfaces
{
    public interface IGroupsCache
    {
        public Task<List<GroupModel>> GetAllGroupsAsync();
    }
}
