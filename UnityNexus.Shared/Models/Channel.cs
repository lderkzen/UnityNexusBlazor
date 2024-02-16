namespace UnityNexus.Shared.Models
{
    public record NotificationChannel(
        string Name,
        string id,
        RemoteChannelType Type
    );
}
