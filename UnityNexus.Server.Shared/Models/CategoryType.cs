namespace UnityNexus.Server.Shared.Models
{
    [Table("category_types")]
    public partial class CategoryType
    {
        public CategoryType()
        {
            CategoryTypeId = UnityNexus.Shared.Enums.CategoryType.Undefined;
            Name = string.Empty;

            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("category_type_id")]
        public UnityNexus.Shared.Enums.CategoryType CategoryTypeId { get; set; }
        
        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
