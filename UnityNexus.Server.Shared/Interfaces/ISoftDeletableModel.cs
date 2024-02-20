namespace UnityNexus.Server.Shared.Interfaces
{
    public interface ISoftDeletableModel
    {
        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted => DeletedAt.HasValue;
    }
}
