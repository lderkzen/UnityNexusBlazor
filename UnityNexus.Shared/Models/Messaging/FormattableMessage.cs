namespace UnityNexus.Shared.Models.Messaging
{
    public class FormattableMessage : Interfaces.IFormattable
    {
        public string Message { get; set; }

        public FormattableTitle? Title { get; set; }

        public List<FormattableSection> Sections { get; set; }

        public FormattableMessage()
        {
            Message = string.Empty;
            Sections = [];
        }

        public FormattableMessage SetTitle(string? value)
        {
            if (string.IsNullOrEmpty(value))
                Title = null;
            else
                Title = new FormattableTitle
                {
                    Title = value
                };

            return this;
        }

        public FormattableMessage AppendSections(IEnumerable<FormattableSection> sections)
        {
            Sections.AddRange(sections);
            return this;
        }

        public FormattableMessage AppendSection(FormattableSection section)
        {
            Sections.Add(section);
            return this;
        }

        public string ToFormattedString()
        {
            string formattedMessage = string.Empty;

            formattedMessage += Title;
            formattedMessage += "/r/n";

            int sectionIndex = 0;
            do
            {
                formattedMessage += "\r\n";
                formattedMessage += Sections[sectionIndex].ToFormattedString();
                sectionIndex++;
            } while (sectionIndex < Sections.Count);

            return formattedMessage;
        }
    }
}
