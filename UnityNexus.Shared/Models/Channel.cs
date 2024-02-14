namespace UnityNexus.Shared.Models
{
    public record Channel(
        string Name,
        string id,
        RemoteChannelType Type
    );
}
