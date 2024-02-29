namespace UnityNexus.Shared.Models
{
    public class SubmissionModel
    {
        private List<AnswerModel> _answers;

        public SubmissionId SubmissionId { get; set; }
        
        public FormId FormId { get; set; }

        public UserId ApplicantId { get; set; }

        public SubmissionStatusModel SubmissionStatus { get; set; }

        public VisibilityLevelModel VisibilityLevel { get; set; }

        public DateTime? CreatedAt { get; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; }

        public bool IsDeleted => DeletedAt.HasValue;

        public List<AnswerModel> Answers
        {
            get => _answers.OrderBy(a => a.Question.Position).ToList();
            set => _answers = value.IfNotNull();
        }

        public SubmissionModel()
        {
            _answers = [];
            SubmissionId = SubmissionId.Unspecified;
            FormId = FormId.Unspecified;
            ApplicantId = (UserId)Guid.Empty;
            SubmissionStatus = new SubmissionStatusModel();
            VisibilityLevel = new VisibilityLevelModel();
        }
    }
}
