namespace UnityNexus.Server.Shared.Models
{
    [Table("open_groups")]
    public partial class OpenGroup : Group
    {
        [Column("group_type")]
        public override GroupType GroupType => GroupType.Open;

        public OpenGroup() : base()
        {
        }
    }
}
