namespace HandOfUnity.Database.Interfaces
{
    public interface IEntity
    {
        /// <summary>
        /// Called before this entity is inserted into the database.
        /// </summary>
        /// <param name="nowUtc"></param>
        public Task OnCreateAsync(DateTime nowUtc)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called just before this entity's database entry is updated.
        /// </summary>
        /// <param name="nowUtc"></param>
        public Task OnUpdateAsync(DateTime nowUtc)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called just before this entity is deleted from the database, or when it is soft-deleted.
        /// </summary>
        /// <param name="nowUtc"></param>
        public Task OnDeleteAsync(DateTime nowUtc)
        {
            return Task.CompletedTask;
        }
    }
}
