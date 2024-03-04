namespace UnityNexus.Server.Database.Interceptors
{
    public class CreateInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result
        )
        {
            if (eventData.Context is null)
                return result;

            eventData.Context.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added && t.Entity.GetType().IsAssignableTo(typeof(ICreatableModel)))
                .ToList()
                .ForEach(e => ((ICreatableModel)e.Entity).Create());

            return result;
        }
    }
}
