namespace UnityNexus.Shared.Entities
{
    public class Category : KeyedEntity
    {
        public required string Name { get; set; }

        public required byte Position { get; set; }
    }
}
