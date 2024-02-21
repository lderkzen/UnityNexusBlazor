namespace UnityNexus.Server.Shared.Models
{
    [Table("answer_types")]
    public partial class AnswerType
    {
        public AnswerType()
        {
            AnswerTypeId = AnswerTypeId.Unspecified;
            Name = string.Empty;

            Questions = new HashSet<Question>();
        }

        [Key]
        [Column("answer_type_id")]
        public AnswerTypeId AnswerTypeId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("position")]
        public short Position { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
