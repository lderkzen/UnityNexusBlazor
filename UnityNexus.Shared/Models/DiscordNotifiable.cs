namespace UnityNexus.Shared.Models
{
    public record DiscordNotifiable : INotifiable, IReadableNotifiable, Interfaces.IFormattable
    {
        public required string Identifier { get; set; }
        public required string ReadableIdentifier { get; set; }
        public required NotifiableType Type { get; set; }
        public bool ShouldIdentify { get; set; }

        public string ToFormattedString()
        {
            return $"@{Identifier}";
        }
    }
}
