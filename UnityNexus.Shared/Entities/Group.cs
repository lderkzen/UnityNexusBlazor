using UnityNexus.Shared.Entities.Abstract;

namespace UnityNexus.Shared.Entities
{
    public class Group : KeyedEntity
    {
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? DiscordChannelId { get; set; }
        public DiscordChannel? DiscordChannel { get; set; }

        public required string Name { get; set; }

        public required string Outline { get; set; }

        public string? Description { get; set; }

        public bool Recruiting { get; set; }

        public required byte Position { get; set; }
    }
}
