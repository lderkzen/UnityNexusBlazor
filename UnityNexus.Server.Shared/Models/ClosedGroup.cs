namespace UnityNexus.Server.Shared.Models
{
    [Table("closed_groups")]
    public partial class ClosedGroup : Group
    {
        [Column("group_type")]
        public override GroupType GroupType => GroupType.Closed;

        public ClosedGroup() : base()
        {
        }

        public virtual Form? ApplicationForm { get; set; }
    }
}
