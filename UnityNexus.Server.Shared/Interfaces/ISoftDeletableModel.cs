namespace UnityNexus.Server.Shared.Interfaces
{
    public interface ISoftDeletableModel
    {
        public DateTime? DeletedAt { get; set; }

        [NotMapped]
        public bool IsDeleted => DeletedAt.HasValue;

        public void Delete()
        {
            DeletedAt = DateTime.UtcNow;
        }
    }
}
