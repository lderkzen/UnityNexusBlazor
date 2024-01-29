namespace UnityNexus.Shared.Models.Messaging
{
    public class FormattableHeader : Interfaces.IFormattable
    {
        public required string Header { get; set; }

        public bool Plain { get; set; }

        public string ToFormattedString()
        {
            return Plain ? Header : $"  __{Header}__";
        }
    }
}
