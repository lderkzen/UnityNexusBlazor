namespace UnityNexus.Server.Shared.Models
{
    [Table("submission_statusses")]
    public partial class SubmissionStatus
    {
        public SubmissionStatus()
        {
            Name = string.Empty;
            Submissions = new HashSet<Submission>();
        }

        [Key]
        [Column("submission_status_id")]
        public UnityNexus.Shared.Enums.SubmissionStatus SubmissionStatusId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("position")]
        public short Position { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}
