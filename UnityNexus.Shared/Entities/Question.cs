namespace UnityNexus.Shared.Entities
{
    [Table("questions")]
    public class Question : ISoftDeletableEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("form_id")]
        public required int FormId { get; set; }

        [Column("type")]
        public required QuestionType Type { get; set; }

        [Column("content")]
        public required string Content { get; set; }

        [Column("created_at")]
        public required DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public required Form Form { get; set; }

        public ICollection<Answer> Answers { get; } = [];
    }
}
