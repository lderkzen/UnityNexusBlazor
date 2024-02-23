namespace UnityNexus.Server.Shared.Models
{
    [Table("group_types")]
    public partial class GroupType
    {
        public GroupType()
        {
            Name = string.Empty;
            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("group_type_id")]
        public UnityNexus.Shared.Enums.GroupType GroupTypeId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("position")]
        public short Position { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
