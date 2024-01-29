namespace UnityNexus.Database.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }


    }
}
