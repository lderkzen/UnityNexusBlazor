namespace UnityNexus.Shared.Models
{
    public class AnswerModel
    {
        private string _content;

        public AnswerId AnswerId { get; set; }

        public string Content
        {
            get => _content;
            set => _content = value.IfNotNull();
        }

        public QuestionModel Question { get; set; }
    
        public AnswerModel? PreviousAnswer { get; set; }

        public DateTime? CreatedAt { get; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; }

        public bool IsDeleted => DeletedAt.HasValue;

        public AnswerModel()
        {
            _content = string.Empty;
            AnswerId = AnswerId.Unspecified;
            Question = new QuestionModel();
        }
    }
}
