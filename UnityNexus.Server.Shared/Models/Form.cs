namespace UnityNexus.Server.Shared.Models
{
    [Table("forms")]
    public partial class Form : ICreatableModel, IUpdatableModel, ISoftDeletableModel
    {
        public Form()
        {
            FormId = FormId.From(0);
            Topic = string.Empty;

            Questions = new HashSet<Question>();
            Submissions = new HashSet<Submission>();
        }

        [Key]
        [Column("form_id")]
        public FormId FormId { get; set; }

        [Column("group_id")]
        public GroupId? GroupId { get; set; }

        [Column("topic")]
        public string Topic { get; set; }

        [Column("is_application_form")]
        public bool IsApplicationForm { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public virtual Group? Group { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }

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
