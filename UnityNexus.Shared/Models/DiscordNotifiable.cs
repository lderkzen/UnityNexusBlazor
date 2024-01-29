namespace UnityNexus.Shared.Models
{
    public record DiscordNotifiable : INotifiable<ulong>, IReadableNotifiable, Interfaces.IFormattable
    {
        public required ulong Identifier { get; set; }
        public required string ReadableIdentifier { get; set; }
        public required DiscordNotifiableType Type { get; set; }
        public bool ShouldIdentify { get; set; }

        public string ToFormattedString()
        {
            return $"@{Identifier}";
        }
    }
}
