namespace UnityNexus.Shared.Entities
{
    [Table("groups")]
    public class Group : ISoftDeletableEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("category_id")]
        public int? CategoryId { get; set; }

        [Column("notification_channel_id")]
        public int? NotificationChannelId { get; set; }

        [Column("owner_id")]
        public int OwnerId { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("intro")]
        public required string Intro { get; set; }

        [Column("recruiting")]
        public bool Recruiting { get; set; }

        [Column("position")]
        public required byte Position { get; set; }

        [Column("created_at")]
        public required DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public Category? Category { get; set; }
        public RemoteChannel? NotificationChannel { get; set; }
        public required NexusUser Owner { get; set; }

        public ICollection<Form> Forms { get; } = [];
    }
}
