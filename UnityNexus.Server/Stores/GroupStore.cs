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
    }
}
