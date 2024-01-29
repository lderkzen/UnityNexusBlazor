namespace UnityNexus.Shared.Models.Messaging
{
    public class DiscordMessage : FormattableMessage
    {
        public required IEnumerable<DiscordNotifiable> Subscribers { get; set; }

        public bool Embedded { get; set; }
    }
}
