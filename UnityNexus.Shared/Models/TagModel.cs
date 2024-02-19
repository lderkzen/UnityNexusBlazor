using UnityNexus.Shared.Extensions;

namespace UnityNexus.Shared.Models
{
    public class TagModel
    {
        private string _content;
        
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Content
        {
            get => _content;
            set => _content = value.IfNotNull();
        }

        public TagModel()
        {
            Id = 0;
            _content = string.Empty;
        }

        public void Update(TagModel other)
        {
            ArgumentNullException.ThrowIfNull(other);

            Id = other.Id;
            Content = other.Content;
        }
    }
}
