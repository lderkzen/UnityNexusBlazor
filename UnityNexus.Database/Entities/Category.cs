namespace UnityNexus.Shared.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required byte Position { get; set; }
    }
}
