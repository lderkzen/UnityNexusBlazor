namespace UnityNexus.Shared.Entities
{
    [Table("remote_channels")]
    public class RemoteChannel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("remote_id")]
        public required string DiscordId { get; set; }

        [Column("type")]
        public required RemoteChannelType Type { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        public ICollection<Group> NotificationChannelFor { get; } = [];
    }
}
