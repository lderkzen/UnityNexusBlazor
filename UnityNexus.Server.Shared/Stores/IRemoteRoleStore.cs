namespace UnityNexus.Server.Shared.Stores
{
    public interface IRemoteRoleStore
    {
        public Task<Role[]> GetAllRolesAsync();
    }
}
