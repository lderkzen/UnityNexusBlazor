using UnityNexus.Server.Shared.Models;

namespace UnityNexus.Server.Shared
{
    public class TagStore : ITagStore
    {
        private readonly UnityNexusContext _unityNexusContext;

        public TagStore(UnityNexusContext unityNexusContext)
        {
            _unityNexusContext = unityNexusContext;
        }

        public async Task<List<Tag>> GetAllTagsAsync(bool tracking = false)
        {
            IQueryable<Tag> query = _unityNexusContext.Tags.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<bool> IsUsedAsync(TagId tagId) =>
            ((await _unityNexusContext.Tags.FirstOrDefaultAsync(t => t.TagId == tagId))?.Groups.Count ?? 0) > 0;

        public void CreateTag(Tag tag)
        {
            tag.TagId = null!;
            _unityNexusContext.Tags.Add(tag);
        }

        public async Task<Exception?> DeleteTagAsync(Tag tag)
        {
            try {
                _unityNexusContext.Tags.Remove(tag);
                await _unityNexusContext.SaveChangesAsync();
            } catch (Exception e)
            {
                return e;
            }

            return null;
        }

        public async Task<Exception?> SaveChangesAsync()
        {
            try {
                await _unityNexusContext.SaveChangesAsync();
            } catch (Exception e)
            {
                return e;
            }

            return null;
        }
    }
}
