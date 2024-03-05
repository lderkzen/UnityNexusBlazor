namespace UnityNexus.Server.Shared.Stores
{
    public interface ITagStore
    {
        public Task<List<Tag>> GetAllTagsAsync(bool tracking = false);

        public Task<bool> IsUsedAsync(TagId tagId);

        public void CreateTag(Tag tag);

        public Task<Exception?> DeleteTagAsync(Tag tag);

        public Task<Exception?> SaveChangesAsync();
    }
}
