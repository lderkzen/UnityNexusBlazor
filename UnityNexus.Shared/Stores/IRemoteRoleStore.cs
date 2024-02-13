namespace UnityNexus.Shared.Stores
{
    public interface IRemoteRoleStore
    {
        Task<RemoteRole[]> GetAllRolesAsync();
    }
}
