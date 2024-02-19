
namespace UnityNexus.Server.Stores
{
    public class AppConfigurationStore : IAppConfigurationStore
    {
        private readonly UnityNexusContext _unityNexusContext;
        private readonly ILogger<AppConfigurationStore> _logger;

        public AppConfigurationStore(
            UnityNexusContext unityNexusContext,
            ILogger<AppConfigurationStore> logger
        )
        {
            _unityNexusContext = unityNexusContext;
            _logger = logger;
        }

        private async Task<Exception?> UpdateEntriesInternalAsync(IReadOnlyDictionary<string, string?> entries)
        {
            try
            {
                var configurationEntries = await _unityNexusContext
                    .ConfigurationEntry
                    
            }
        }

        public Task<Dictionary<string, string?>> LoadEntriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Exception?> UpdateEntriesAsync(IReadOnlyDictionary<string, string?> entries)
        {
            throw new NotImplementedException();
        }
    }
}
