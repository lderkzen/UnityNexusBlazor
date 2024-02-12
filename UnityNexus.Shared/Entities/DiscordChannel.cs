using System.ComponentModel;

namespace UnityNexus.Shared.Entities
{
    public class DiscordChannel
    {
        [Key]
        public int Id { get; set; }

        public required string DiscordId { get; set; }

        [DefaultValue((byte)DiscordChannelType.Unknown)]
        public required DiscordChannelType Type { get; set; }

        public required string Name { get; set; }
    }
}
