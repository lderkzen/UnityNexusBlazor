namespace UnityNexus.Server.Shared.Models
{
    [Table("category_types")]
    public partial class CategoryType
    {
        public CategoryType()
        {
            Name = string.Empty;
            Categories = new HashSet<Category>();
        }

        [Key]
        [Column("category_type_id")]
        public UnityNexus.Shared.Enums.CategoryType CategoryTypeId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("position")]
        public short Position { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
