namespace UnityNexus.Server.Shared.Stores
{
    public interface IGroupStore
    {
        public Task<List<Group>> GetAllGroupsAsync(bool tracking);
        public Task<Group?> GetGroupAsync(int groupId, bool tracking);
    }
}
