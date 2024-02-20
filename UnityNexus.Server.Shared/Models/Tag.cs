namespace UnityNexus.Server.Shared.Models
{
    [Table("tags")]
    public partial class Tag
    {
        public Tag()
        {
            TagId = TagId.From(0);
            Content = string.Empty;

            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("tag_id")]
        public TagId TagId { get; set; }

        [MaxLength(50)]
        [Column("content")]
        public string Content { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
