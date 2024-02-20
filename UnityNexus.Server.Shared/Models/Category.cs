namespace UnityNexus.Server.Shared.Models
{
    [Table("categories")]
    public partial class Category
    {
        public Category()
        {
            CategoryId = CategoryId.From(0);
            CategoryTypeId = CategoryType.Undefined;
            Name = string.Empty;

            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("category_id")]
        public CategoryId CategoryId { get; set; }

        [Column("category_type_id")]
        public CategoryType CategoryTypeId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
