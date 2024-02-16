using System.ComponentModel;
using UnityNexus.Shared.Extensions;

namespace UnityNexus.Shared.Models
{
    public class GroupModel
    {
        private string _name;
        private string _intro;

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
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

        public Guid? UserId { get; set; }

        public int? CategoryId { get; set; }
        
        public string? NotificationChannelId { get; set; }

        public bool IsLocked { get; set; }

        public byte Position { get; set; }

        private string? Image { get; set; }

        public DateTime? CreatedAt { get; }

        public DateTime? UpdatedAt { get; }

        public DateTime? DeletedAt { get; }

        public bool IsDeleted => DeletedAt.HasValue;

        public GroupModel()
        {
            Id = 0;
            _name = string.Empty;
            _intro = string.Empty;
            IsLocked = true;
            Position = 0;
        }

        public void Update(GroupModel other)
        {
            ArgumentNullException.ThrowIfNull(other);

            Id = other.Id;
            Name = other.Name;
            Intro = other.Intro;
            IsLocked = other.IsLocked;
            Position = other.Position;
            Image = other.Image;
        }
    }
}
