
namespace UnityNexus.Client.Caches
{
    public class GroupsCache : IGroupsCache
    {
        public GroupsCache()
        {
        }

        public Task<List<GroupModel>> GetAllGroupsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
