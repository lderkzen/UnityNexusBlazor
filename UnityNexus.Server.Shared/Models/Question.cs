using Microsoft.EntityFrameworkCore;

namespace UnityNexus.Server.Shared.Models
{
    [Table("questions")]
    [Index(nameof(FormId), nameof(Position))]
    public partial class Question
    {
        public Question()
        {
            QuestionId = QuestionId.From(0);
            FormId = FormId.From(0);
            Content = string.Empty;

            Answers = new HashSet<Answer>();
        }

        [Key]
        [Column("question_id")]
        public QuestionId QuestionId { get; set; }

        [Column("form_id")]
        public FormId FormId { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("answer_type_id")]
        public UnityNexus.Shared.Enums.AnswerType AnswerTypeId { get; set; }

        [Column("required")]
        public bool IsRequired { get; set; }

        [Column("position")]
        public short Position { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public virtual Form Form { get; set; } = null!;
        public virtual AnswerType AnswerType { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
