using System.ComponentModel;

namespace UnityNexus.Shared.Entities
{
    public class DiscordUser
    {
        [Key]
        public int Id { get; set; }

        public required ulong DiscordId { get; set; }

        public required string Username { get; set; }

        public required string DisplayName { get; set; }

        [DefaultValue(NotificationFlag.Unconfigured)]
        public required NotificationFlag NotificationFlagSum { get; set; }

        public ICollection<DiscordRole> Roles { get; } = [];
    }
}
