namespace UnityNexus.Shared.Entities
{
    [Table("remote_roles")]
    public class RemoteRole
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("remote_id")]
        public required string RemoteId { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        public ICollection<NexusUser> Users { get; } = [];
    }
}
