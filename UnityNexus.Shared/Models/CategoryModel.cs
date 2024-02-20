using UnityNexus.Shared.Extensions;

namespace UnityNexus.Shared.Models
{
    public class CategoryModel
    {
        private string _name;
        private List<GroupId> _groupIds;

        public CategoryId CategoryId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name
        {
            get => _name;
            set => _name = value.IfNotNull();
        }

        public List<GroupId> GroupIds
        {
            get => _groupIds;
            set => _groupIds = value.IfNotNull();
        }

        public DateTime? CreatedAt { get; }

        public DateTime? UpdatedAt { get; }

        public CategoryModel()
        {
            CategoryId = CategoryId.From(0);
            _name = string.Empty;
            _groupIds = [];
        }

        public void Update(CategoryModel other)
        {
            ArgumentNullException.ThrowIfNull(other);

            CategoryId = other.CategoryId;
            Name = other.Name;
            GroupIds = other.GroupIds;
        }
    }
}
