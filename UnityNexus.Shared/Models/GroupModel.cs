using UnityNexus.Shared.Extensions;

namespace UnityNexus.Shared.Models
{
    public class GroupModel
    {
        private string _title;
        private string _intro;
        private List<int> _tagIds;

        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Title
        {
            get => _title;
            set => _title = value.IfNotNull();
        }

        [Required]
        [MaxLength(1024)]
        public string Intro
        {
            get => _intro;
            set => _intro = value.IfNotNull();
        }

        public List<int> TagIds
        {
            get => _tagIds;
            set => _tagIds = value.IfNotNull();
        }

        public Guid? UserId { get; set; }

        public int? CategoryId { get; set; }
        
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
            Id = 0;
            _title = string.Empty;
            _intro = string.Empty;
            _tagIds = [];
            IsLocked = true;
            Position = 0;
        }

        public void Update(GroupModel other)
        {
            ArgumentNullException.ThrowIfNull(other);

            Id = other.Id;
            Title = other.Title;
            Intro = other.Intro;
            TagIds = other.TagIds;
            IsLocked = other.IsLocked;
            Position = other.Position;
            Image = other.Image;
        }
    }
}
