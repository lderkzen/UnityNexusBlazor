namespace UnityNexus.Server.Shared.Models
{
    [Table("configuration_entries")]
    public partial class ConfigurationEntry
    {
        public ConfigurationEntryId ConfigurationEntryId { get; set; }
        public string? Key { get; set; } = null!;
        public string? Value { get; set; }

        public ConfigurationEntry()
        {
            ConfigurationEntryId = ConfigurationEntryId.Unspecified;
        }
    }
}
