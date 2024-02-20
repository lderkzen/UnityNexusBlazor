using UnityNexus.Shared.Extensions;

namespace UnityNexus.Shared.Models
{
    public class GroupModel
    {
        private string _name;
        private string _intro;
        private List<TagId> _tagIds;

        public GroupId GroupId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name
        {
            get => _name;
            set => _name = value.IfNotNull();
        }

        [Required]
        [MaxLength(1024)]
        public string Intro
        {
            get => _intro;
            set => _intro = value.IfNotNull();
        }

        public List<TagId> TagIds
        {
            get => _tagIds;
            set => _tagIds = value.IfNotNull();
        }

        public Guid? UserId { get; set; }

        public CategoryId? CategoryId { get; set; }
        
        public string? NotificationChannelId { get; set; }

        public bool IsLocked { get; set; }

        public byte Position { get; set; }

        public string? Image { get; set; }

        public DateTime? CreatedAt { get; }

        public DateTime? UpdatedAt { get; }

        public DateTime? DeletedAt { get; }

        public bool IsDeleted => DeletedAt.HasValue;

        public GroupModel()
        {
            GroupId = GroupId.From(0);
            _name = string.Empty;
            _intro = string.Empty;
            _tagIds = [];
            IsLocked = true;
            Position = 0;
        }

        public void Update(GroupModel other)
        {
            ArgumentNullException.ThrowIfNull(other);

            GroupId = other.GroupId;
            Name = other.Name;
            Intro = other.Intro;
            TagIds = other.TagIds;
            IsLocked = other.IsLocked;
            Position = other.Position;
            Image = other.Image;
        }
    }
}
