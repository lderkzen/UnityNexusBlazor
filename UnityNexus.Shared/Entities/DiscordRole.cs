namespace UnityNexus.Shared.Entities
{
    public class DiscordRole
    {
        [Key]
        public int Id { get; set; }

        public required string DiscordId { get; set; }

        public required string Name { get; set; }

        public ICollection<DiscordUser> Users { get; } = [];
    }
}
