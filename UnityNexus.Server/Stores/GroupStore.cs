namespace UnityNexus.Server.Stores
{
    public class GroupStore : IGroupStore
    {
        private readonly UnityNexusContext _unityNexusContext;

        public GroupStore(UnityNexusContext unityNexusContext)
        {
            _unityNexusContext = unityNexusContext;
        }

        private IQueryable<Group> GetBaseQueryable(bool tracking)
        {
            IQueryable<Group> query = _unityNexusContext
                .Groups
                .OrderBy(c => c.GroupId)
                .AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public async Task<Group> GetGroupByIdAsync(GroupId groupId, bool tracking = false)
        {
            return await GetBaseQueryable(tracking).FirstAsync(m => m.GroupId == groupId);
        }

        public async Task<List<Group>> GetAllGroupsAsync(bool tracking = false)
        {
            return await GetBaseQueryable(tracking).ToListAsync();
        }

        public async Task<int> CountGroupsByFilterAsync(string? filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return await _unityNexusContext.Groups.CountAsync();
            return await _unityNexusContext.Groups.CountAsync(m => m.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<List<Group>> GetGroupsByFilterAsync(string? filter, bool tracking = false)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return await GetAllGroupsAsync(tracking);
            return await GetBaseQueryable(tracking).Where(m => m.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        public async Task<List<Group>> GetGroupsByFilterAndPageAsync(string? filter, int skip, int take, bool tracking = false)
        {
            IQueryable<Group> query = GetBaseQueryable(tracking);

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(m => m.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));

            return await query.Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<int> CountMembersByGroupIdAsync(GroupId groupId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetAllMembersByGroupIdAsync(GroupId groupId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountMembersAsync(Group group)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetAllMembersAsync(Group group)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterMemberAsync(Group group, UserId userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveMemberAsync(Group group, UserId userId)
        {
            throw new NotImplementedException();
        }

        public void CreateGroup(Group group)
        {
            group.GroupId = null!;
            _unityNexusContext.Groups.Add(group);
        }

        public async Task<(Dictionary<string, (string OldValue, string newValue)>? Changes, Exception? Exception)> UpdateGroupAsync(
            Group dbEntity,
            Group requestEntity
        )
        {
            throw new NotImplementedException();
        }

        public async Task<Exception?> DeleteGroupAsync(Group group)
        {
            try
            {
                _unityNexusContext.Groups.Remove(group);
                await _unityNexusContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return e;
            }

            return null;
        }

        public async Task<Exception?> DestroyDeletedGroupAsync(Group group)
        {
            throw new NotImplementedException();
        }

        public async Task<Exception?> SaveChangesAsync()
        {
            try
            {
                await _unityNexusContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return e;
            }

            return null;
        }
    }
}
