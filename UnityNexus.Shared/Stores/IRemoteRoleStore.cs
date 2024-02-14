namespace UnityNexus.Shared.Stores
{
    public interface IRemoteRoleStore
    {
        public Task<Role[]> GetAllRolesAsync();
    }
}
