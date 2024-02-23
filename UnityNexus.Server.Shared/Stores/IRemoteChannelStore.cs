namespace UnityNexus.Server.Shared.Stores
{
    public interface IRemoteChannelStore
    {
        public Task<List<NotificationChannel>> GetAllChannelsAsync();
        public Task<List<NotificationChannel>> GetAllChannelsByTypeAsync(ChannelType channelType);
    }
}
