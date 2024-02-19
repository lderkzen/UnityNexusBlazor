namespace UnityNexus.Server.Shared.Entities
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
        public Guid? NotificationChannelId { get; set; }

        [Column("owner_id")]
        public Guid? OwnerId { get; set; }

        [Column("title")]
        public required string Title { get; set; }

        [Column("intro")]
        public required string Intro { get; set; }

        [Column("locked")]
        public bool Locked { get; set; }

        [Column("position")]
        public required byte Position { get; set; }

        [Column("image")]
        public string? Image { get; set; }

        [Column("created_at")]
        public required DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public Category? Category { get; set; }

        public ICollection<Form> Forms { get; } = [];
    }
}
