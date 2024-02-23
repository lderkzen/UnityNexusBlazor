namespace UnityNexus.Server.Shared.Models
{
    [Table("answer_types")]
    public partial class AnswerType
    {
        public AnswerType()
        {
            AnswerTypeId = UnityNexus.Shared.Enums.AnswerType.Unspecified;
            Name = string.Empty;

            Questions = new HashSet<Question>();
        }

        [Key]
        [Column("answer_type_id")]
        public UnityNexus.Shared.Enums.AnswerType AnswerTypeId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("position")]
        public short Position { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
