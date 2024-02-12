namespace UnityNexus.Shared.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? CommunicationChannelId { get; set; }
        public DiscordChannel? CommunicationChannel { get; set; }

        public int OwnerId { get; set; }
        public DiscordUser Owner { get; set; }

        public required string Name { get; set; }

        public required string Outline { get; set; }

        public string? Description { get; set; }

        public bool Recruiting { get; set; }

        public required byte Position { get; set; }
    }
}
