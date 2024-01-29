namespace UnityNexus.Shared.Models.Messaging
{
    public class FormattableSection : Interfaces.IFormattable
    {
        public FormattableHeader? Header { get; set; }

        public required string Section { get; set; }

        public bool Plain { get; set; }

        public string ToFormattedString()
        {
            string formattedSection = string.Empty;

            formattedSection += Header?.ToFormattedString();
            formattedSection += "\r\n";
            formattedSection += Section;

            return formattedSection;
        }
    }
}
