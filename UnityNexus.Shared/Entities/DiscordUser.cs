using System.ComponentModel;

namespace UnityNexus.Shared.Entities
{
    public class DiscordUser : KeyedEntity
    {
        public required ulong DiscordId { get; set; }

        public required string Username { get; set; }

        public required string DisplayName { get; set; }

        [DefaultValue((byte)NotificationFlag.Unconfigured)]
        public required NotificationFlag NotificationFlagSum { get; set; }

        public ICollection<DiscordRole> Roles { get; } = [];
    }
}
