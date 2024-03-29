using Microsoft.EntityFrameworkCore;

namespace UnityNexus.Server.Shared.Models
{
    [Table("submission")]
    [Index(nameof(ApplicantId))]
    [Index(nameof(SubmissionStatusId))]
    public partial class Submission : ICreatableModel, IUpdatableModel, ISoftDeletableModel
    {
        public Submission()
        {
            SubmissionId = SubmissionId.From(0);
            FormId = FormId.From(0);
            ApplicantId = (UserId)Guid.Empty;

            Answers = new HashSet<Answer>();
        }

        [Key]
        [Column("submission_id")]
        public SubmissionId SubmissionId { get; set; }

        [Column("form_id")]
        public FormId FormId { get; set; }

        [Column("applicant_id")]
        public UserId ApplicantId { get; set; }

        [Column("submission_status_id")]
        public UnityNexus.Shared.Enums.SubmissionStatus SubmissionStatusId { get; set; }

        [Column("visibility_level_id")]
        public UnityNexus.Shared.Enums.VisibilityLevel VisibilityLevelId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public virtual SubmissionStatus SubmissionStatus { get; set; } = null!;
        public virtual VisibilityLevel VisibilityLevel { get; set; } = null!;
        public virtual Form Form { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }

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
