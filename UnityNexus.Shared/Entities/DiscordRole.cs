namespace UnityNexus.Shared.Entities
{
    public class DiscordRole : KeyedEntity
    {
        public required ulong DiscordId { get; set; }

        public required string Name { get; set; }

        public ICollection<DiscordUser> Users { get; } = [];
    }
}
