namespace UnityNexus.Shared.Stores
{
    public interface IRemoteRoleStore
    {
        Task<Role[]> GetAllRolesAsync();
    }
}
