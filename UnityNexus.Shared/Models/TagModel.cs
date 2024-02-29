namespace UnityNexus.Shared.Models
{
    public class TagModel
    {
        private string _content;

        public TagId TagId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Content
        {
            get => _content;
            set => _content = value.IfNotNull();
        }

        public TagModel()
        {
            TagId = TagId.From(0);
            _content = string.Empty;
        }

        public void Update(TagModel other)
        {
            ArgumentNullException.ThrowIfNull(other);

            TagId = other.TagId;
            Content = other.Content;
        }
    }
}
