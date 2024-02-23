namespace UnityNexus.Server.Shared.Models
{
    [Table("visibility_levels")]
    public partial class VisibilityLevel
    {
        public VisibilityLevel()
        {
            Name = string.Empty;
            Submissions = new HashSet<Submission>();
        }

        [Key]
        [Column("visibility_level_id")]
        public UnityNexus.Shared.Enums.VisibilityLevel VisibilityLevelId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("position")]
        public short Position { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
