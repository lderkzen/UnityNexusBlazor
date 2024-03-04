namespace UnityNexus.Server.Shared.Models
{
    [Table("answers")]
    public partial class Answer : ICreatableModel, IUpdatableModel, ISoftDeletableModel
    {
        public Answer()
        {
            AnswerId = AnswerId.From(0);
            QuestionId = QuestionId.From(0);
            SubmissionId = SubmissionId.From(0);
            Content = string.Empty;
        }

        [Key]
        [Column("answer_id")]
        public AnswerId AnswerId { get; set; }

        [Column("previous_answer_id")]
        public AnswerId? PreviousAnswerId { get; set; }

        [Column("question_id")]
        public QuestionId QuestionId { get; set; }

        [Column("submission_id")]
        public SubmissionId SubmissionId { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual Submission Submission { get; set; } = null!;

        public virtual Answer? PreviousAnswer { get; set; }

        public void Create()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
