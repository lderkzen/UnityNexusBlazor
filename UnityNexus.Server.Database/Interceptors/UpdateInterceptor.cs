namespace UnityNexus.Server.Database.Interceptors
{
    public class UpdateInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result
        )
        {
            if (eventData.Context is null)
                return result;

            eventData.Context.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified && t.Entity.GetType().IsAssignableTo(typeof(IUpdatableModel)))
                .ToList()
                .ForEach(e => ((IUpdatableModel)e.Entity).Update());

            return result;
        }
    }
}
