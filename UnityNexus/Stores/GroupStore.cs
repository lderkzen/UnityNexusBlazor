using Microsoft.EntityFrameworkCore;

namespace UnityNexus.Stores
{
    public class GroupStore : IGroupStore
    {
        private readonly UnityNexusContext _unityNexusContext;

        public GroupStore(UnityNexusContext unityNexusContext)
        {
            _unityNexusContext = unityNexusContext;
        }

        public async Task<List<Group>> GetAllGroupsAsync(bool tracking)
        {
            IQueryable<Group> query = _unityNexusContext
                .Groups
                .AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<Group?> GetGroupAsync(int groupId, bool tracking)
        {
            IQueryable<Group> query = _unityNexusContext
                .Groups
                .Include(g => g.Category)
                .Where(g => g.DeletedAt == null)
                .AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(g => g.Id == groupId);
        }
    }
}
