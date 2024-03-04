namespace UnityNexus.Server.Database.Interceptors
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result
        )
        {
            if (eventData.Context is null)
                return result;

            eventData.Context.ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Deleted && t.Entity.GetType().IsAssignableTo(typeof(ISoftDeletableModel)))
                .ToList()
                .ForEach(e =>
                {
                    e.State = EntityState.Modified;
                    ((ISoftDeletableModel)e.Entity).Delete();
                });

            return result;
        }
    }
}
