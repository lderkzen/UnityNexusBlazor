namespace UnityNexus.Server.Shared
{
    [Table("categories")]
    public partial class Category
    {
        public Category()
        {
            CategoryId = CategoryId.From(0);
            CategoryTypeId = CategoryType.Undefined;
            CategoryName = string.Empty;

            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("category_id")]
        public CategoryId CategoryId { get; set; }

        [Column("category_type_id")]
        public UnityNexus.Shared.Enums.CategoryType CategoryTypeId { get; set; }

        [Column("category_name")]
        public string CategoryName { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
