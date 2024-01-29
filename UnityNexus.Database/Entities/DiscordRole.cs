namespace UnityNexus.Database.Entities
{
    public class DiscordRole
    {
        [Key]
        public int Id { get; set; }

        public required ulong DiscordId { get; set; }

        public required string Name { get; set; }

        public ICollection<>
    }
}
