namespace UnityNexus.Shared.Models
{
    public class GroupModel
    {
        private string _name;
        private string _intro;
        private List<TagId> _tagIds;

        public GroupId GroupId { get; set; }
        
        public GroupTypeModel GroupType { get; set; }

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

        public UserId? UserId { get; set; }

        public CategoryModel? Category { get; set; }
        
        public string? NotificationChannelId { get; set; }

        public bool IsLocked { get; set; }

        public byte Position { get; set; }

        public string? LogoPath { get; set; }

        public string? BannerPath { get; set; }

        public DateTime? CreatedAt { get; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; }

        public bool IsDeleted => DeletedAt.HasValue;

        public GroupModel()
        {
            GroupId = GroupId.From(0);
            GroupType = new GroupTypeModel();
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
            GroupType = other.GroupType;
            Name = other.Name;
            Intro = other.Intro;
            TagIds = other.TagIds;
            Category = other.Category;
            NotificationChannelId = other.NotificationChannelId;
            IsLocked = other.IsLocked;
            Position = other.Position;
            LogoPath = other.LogoPath;
            BannerPath = other.BannerPath;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
