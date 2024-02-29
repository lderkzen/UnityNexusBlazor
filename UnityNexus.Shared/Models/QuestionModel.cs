namespace UnityNexus.Shared.Models
{
    public class QuestionModel
    {
        private string _content;

        public QuestionId QuestionId { get; set; }

        public AnswerTypeModel AnswerType { get; set; }

        [MaxLength(255)]
        public string Content 
        {
            get => _content;
            set => _content = value.IfNotNull();
        }

        public bool IsRequired { get; set; }

        public short Position { get; set; }

        public DateTime? CreatedAt { get; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; }

        public bool IsDeleted => DeletedAt.HasValue;

        public QuestionModel()
        {
            _content = string.Empty;
            AnswerType = new AnswerTypeModel();
            QuestionId = QuestionId.Unspecified;
        }
    }
}
