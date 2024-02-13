namespace UnityNexus.Shared.Entities
{
    [Table("forms")]
    public class Form : ISoftDeletableEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("group_id")]
        public int? GroupId { get; set; }

        [Column("topic")]
        public required string Topic { get; set; }

        [Column("created_at")]
        public required DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public Group? Group { get; set; }

        public ICollection<Question> Questions { get; } = [];
        public ICollection<Submission> Submissions { get; } = [];
    }
}
