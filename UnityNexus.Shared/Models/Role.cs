namespace UnityNexus.Shared.Models
{
    public record Role(
        string Name,
        string? HexColorCode,
        byte? PowerLevel
    );
}
