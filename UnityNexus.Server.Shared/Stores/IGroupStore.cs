namespace UnityNexus.Server.Shared.Stores
{
    public interface IGroupStore
    {
        public Task<Group> GetGroupByIdAsync(GroupId groupId, bool tracking = false);
        public Task<List<Group>> GetAllGroupsAsync(bool tracking = false);
        public Task<int> CountGroupsByFilterAsync(string? filter);
        public Task<List<Group>> GetGroupsByFilterAsync(string? filter, bool tracking = false);
        public Task<List<Group>> GetGroupsByFilterAndPageAsync(string? filter, int skip, int take, bool tracking = false);

        public Task<int> CountMembersByGroupIdAsync(GroupId groupId);
        public Task<UserModel> GetAllMembersByGroupIdAsync(GroupId groupId);
        public Task<int> CountMembersAsync(Group group);
        public Task<UserModel> GetAllMembersAsync(Group group);
        public Task<bool> RegisterMemberAsync(Group group, UserId userId);
        public Task<bool> RemoveMemberAsync(Group group, UserId userId);

        public void CreateGroup(Group group);
        public Task<(Dictionary<string, (string OldValue, string newValue)>? Changes, Exception? Exception)> UpdateGroupAsync(
            Group dbEntity,
            Group requestEntity
        );
        public Task<Exception?> DeleteGroupAsync(Group group);
        public Task<Exception?> DestroyDeletedGroupAsync(Group group);
        public Task<Exception?> SaveChangesAsync();
    }
}
