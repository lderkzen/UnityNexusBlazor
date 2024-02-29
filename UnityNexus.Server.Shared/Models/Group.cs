using Microsoft.EntityFrameworkCore;

namespace UnityNexus.Server.Shared.Models
{
    [Table("groups")]
    [Index(nameof(Position))]
    public abstract partial class Group : ISoftDeletableModel
    {
        public Group()
        {
            GroupId = GroupId.From(0);
            ChannelId = ChannelId.From(string.Empty);
            Name = string.Empty;
            Intro = string.Empty;

            MemberIds = new HashSet<UserId>();
            Tags = new HashSet<Tag>();
            Forms = new HashSet<Form>();
        }

        [Key]
        [Column("group_id")]
        public GroupId GroupId { get; set; }

        [Column("group_type_id")]
        public UnityNexus.Shared.Enums.GroupType GroupTypeId { get; set; }

        [Column("category_id")]
        public CategoryId? CategoryId { get; set; }

        [Column("owner_id")]
        public UserId? OwnerId { get; set; }

        [Column("channel_id")]
        public ChannelId ChannelId { get; set; }

        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; }

        [MaxLength(1000)]
        [Column("intro")]
        public string Intro { get; set; }

        [Column("locked")]
        public bool IsLocked { get; set; }

        [Column("position")]
        public short Position { get; set; }

        [Column("logo_path")]
        public string? LogoPath { get; set; }

        [Column("banner_path")]
        public string? BannerPath { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public virtual GroupType GroupType { get; set; } = null!;
        public virtual Category? Category { get; set; }
        public virtual ICollection<UserId> MemberIds { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Form> Forms { get; set; }
    }
}
