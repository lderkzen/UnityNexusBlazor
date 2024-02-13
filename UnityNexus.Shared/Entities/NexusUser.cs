namespace UnityNexus.Shared.Entities
{
    [Table("nexus_users")]
    public class NexusUser
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("discord_id")]
        public string? DiscordId { get; set; }

        [Column("username")]
        public required string Username { get; set; }

        [Column("notification_flag_sum")]
        public required NotificationFlag NotificationFlagSum { get; set; }

        public ICollection<RemoteRole> Roles { get; } = [];
    }
}
