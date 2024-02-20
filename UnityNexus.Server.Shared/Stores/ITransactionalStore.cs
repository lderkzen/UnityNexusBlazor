namespace UnityNexus.Server.Shared.Stores
{
    /// <summary>
    /// Manages transactional operations against the database.
    /// </summary>
    public interface ITransactionalStore
    {
        Task Transactional(Func<Task> act);

        Task<TResult> Transactional<TResult>(Func<Task<TResult>> act);
    }
}
