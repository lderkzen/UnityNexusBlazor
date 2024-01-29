namespace UnityNexus.Shared.Models.Messaging
{
    public class FormattableTitle : Interfaces.IFormattable
    {
        public required string Title { get; set; }

        public bool Plain { get; set; }

        public string ToFormattedString()
        {
            return Plain ? Title : $"> **{Title}**";
        }
    }
}
