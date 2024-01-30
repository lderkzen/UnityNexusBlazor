namespace UnityNexus.Shared.Entities.Abstract
{
    public abstract class KeyedEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
