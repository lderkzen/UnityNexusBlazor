namespace UnityNexus.Shared.Entities
{
    [Table("submissions")]
    public class Submission : ISoftDeletableEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("form_id")]
        public required int FormId { get; set; }

        [Column("applicant_id")]
        public required Guid ApplicantId { get; set; }

        [Column("status")]
        public required SubmissionStatus Status { get; set; }

        [Column("created_at")]
        public required DateTime CreatedAt { get; set; }

        [Column("submitted_at")]
        public DateTime? SubmittedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public required Form Form { get; set; }

        public ICollection<Answer> Answers { get; } = [];
    }
}
