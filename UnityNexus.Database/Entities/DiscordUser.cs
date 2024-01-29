using System.ComponentModel;

namespace UnityNexus.Database.Entities
{
    public class DiscordUser
    {
        [Key]
        public int Id { get; set; }

        public required ulong DiscordId { get; set; }

        public required string Username { get; set; }

        public required string DisplayName { get; set; }

        [DefaultValue(0)]
        public required uint NotificationFlagSum { get; set; }
    }
}
