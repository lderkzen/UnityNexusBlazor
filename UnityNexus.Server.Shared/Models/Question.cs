namespace UnityNexus.Server.Shared.Models
{
    [Table("questions")]
    public partial class Question
    {
        public Question()
        {

        }

        public virtual Form Form { get; set; } = null!;
    }
}
