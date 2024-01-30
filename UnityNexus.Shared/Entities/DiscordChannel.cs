using System.ComponentModel;

namespace UnityNexus.Shared.Entities
{
    public class DiscordChannel : KeyedEntity
    {
        public required ulong DiscordId { get; set; }

        [DefaultValue((byte)DiscordChannelType.Unknown)]
        public required DiscordChannelType Type { get; set; }

        public required string Name { get; set; }
    }
}
