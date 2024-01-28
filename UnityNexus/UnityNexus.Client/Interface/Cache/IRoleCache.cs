namespace UnityNexus.Client.Interface.Cache
{
    public interface IRoleCache
    {
        private Task<IReadOnlyCollection<RoleModel>> GetRolesAsync();
    }
}
