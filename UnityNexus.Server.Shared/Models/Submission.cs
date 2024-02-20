using Microsoft.EntityFrameworkCore;

namespace UnityNexus.Server.Shared.Models
{
    [Table("submission")]
    [Index(nameof(ApplicantId))]
    [Index(nameof(Status))]
    public partial class Submission : ISoftDeletableModel
    {
        public Submission()
        {
            SubmissionId = SubmissionId.From(0);
            FormId = FormId.From(0);

            Answers = new HashSet<Answer>();
        }

        [Key]
        [Column("submission_id")]
        public SubmissionId SubmissionId { get; set; }

        [Column("form_id")]
        public FormId FormId { get; set; }

        [Column("applicant_id")]
        public required UserId ApplicantId { get; set; }
        
        [Column("status")]
        public SubmissionStatus Status { get; set; }

        [Column("visibility_level")]
        public VisibilityLevel VisibilityLevel { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public virtual Form Form { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
