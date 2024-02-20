namespace UnityNexus.Server.Shared.Models
{
    [Table("forms")]
    public partial class Form
    {
        public Form()
        {
            FormId = FormId.From(0);

            Questions = new HashSet<Question>();
        }

        [Key]
        [Column("form_id")]
        public FormId FormId { get; set; }

        public virtual Group? Group { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
