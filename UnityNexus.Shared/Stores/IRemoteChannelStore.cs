namespace UnityNexus.Shared.Stores
{
    public interface IRemoteChannelStore
    {
        public Task<List<Channel>> GetAllChannelsAsync();
        public Task<List<Channel>> GetAllChannelsByTypeAsync(RemoteChannelType channelType);
    }
}
