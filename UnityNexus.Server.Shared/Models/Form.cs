namespace UnityNexus.Server.Shared.Models
{
    [Table("forms")]
    public partial class Form
    {
        public Form()
        {
            FormId = FormId.From(0);
        }

        [Key]
        [Column("form_id")]
        public FormId FormId { get; set; }

        public virtual Group? Group { get; set; }
    }
}
