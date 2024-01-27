namespace HandOfUnity.Database.Interfaces
{
    public interface ISoftDeletableEntity
    {
        /// <summary>
        /// The time at which this entity was soft-deleted.
        /// </summary>
        public DateTime DeletedAtUtc { get; set; }
    }
}
