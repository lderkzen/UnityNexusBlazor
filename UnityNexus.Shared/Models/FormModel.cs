namespace UnityNexus.Shared.Models
{
    public class FormModel
    {
        private string _topic;
        private List<QuestionModel> _questions;
        private List<SubmissionId> _submissionIds;

        public FormId FormId { get; set; }

        [MaxLength(100)]
        public string Topic
        {
            get => _topic;
            set => _topic = value.IfNotNull();
        }

        public DateTime? CreatedAt { get; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; }

        public bool IsDeleted => DeletedAt.HasValue;

        public List<QuestionModel> Questions
        {
            get => _questions.OrderBy(q => q.Position).ToList();
            set => _questions = value.IfNotNull();
        }

        public List<SubmissionId> SubmissionIds
        {
            get => _submissionIds;
            set => _submissionIds = value.IfNotNull();
        }

        public FormModel()
        {
            _topic = string.Empty;
            _questions = [];
            _submissionIds = [];
            FormId = FormId.Unspecified;
        }

        public void Update(FormModel other)
        {
            ArgumentNullException.ThrowIfNull(other);

            FormId = other.FormId;
            Topic = other.Topic;
            UpdatedAt = DateTime.UtcNow;
            Questions = other.Questions;
            SubmissionIds = other.SubmissionIds;
        }
    }
}
