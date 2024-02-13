namespace UnityNexus.Shared.Interfaces
{
    public interface ISoftDeletableEntity
    {
        public DateTime? DeletedAt { get; set; }
    }
}
