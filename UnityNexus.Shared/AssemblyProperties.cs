[assembly: VogenDefaults(
    underlyingType: typeof(int),
    conversions: Conversions.SystemTextJson | Conversions.EfCoreValueConverter,
    debuggerAttributes: DebuggerAttributeGeneration.Full
)]
