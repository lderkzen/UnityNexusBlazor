namespace UnityNexus.Server.Shared.Entities
{
    [Table("answers")]
    public class Answer : ISoftDeletableEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("submission_id")]
        public required int SubmissionId { get; set; }

        [Column("question_id")]
        public required int QuestionId { get; set; }

        [Column("revision_of_id")]
        public int? RevisionOfId { get; set; }

        [Column("content")]
        public required string Content { get; set; }

        [Column("created_at")]
        public required DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public required Submission Submission { get; set; }
        public required Question Question { get; set; }
        public Answer? RevisionOf { get; set; }
    }
}
