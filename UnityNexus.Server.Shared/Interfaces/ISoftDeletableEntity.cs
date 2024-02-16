namespace UnityNexus.Server.Shared.Interfaces
{
    public interface ISoftDeletableEntity
    {
        public DateTime? DeletedAt { get; set; }
    }
}
