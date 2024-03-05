namespace UnityNexus.Server.Shared.Stores
{
    public interface IGroupStore
    {
        public Task<List<Group>> GetAllGroupsAsync(bool tracking = false);
        public Task<List<Form>> GetAllFormsAsync(GroupId groupId, bool tracking = false);

        public Task<int> CountMembersAsync(GroupId groupId);
        public Task<UserModel> GetAllMembersAsync(GroupId groupId);
        public Task<bool> RegisterMembersAsync(Group group, params UserId[] userIds);
        public Task<bool> RemoveMembersAsync(Group group, params UserId[] userIds);
    }
}
