namespace HandOfUnity.Database.Interfaces
{
    public interface ITimeStampedEntity
    {
        /// <summary>
        /// The time at which this entity was updated.
        /// </summary>
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        /// The last time at which this entity was updated.
        /// </summary>
        public DateTime UpdatedAtUtc { get; set; }
    }
}
