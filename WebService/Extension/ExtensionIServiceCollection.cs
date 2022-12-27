
using AbstractDependencies.DiConfig;

namespace DiConfig;

internal static class ExtensionIServiceCollection
{
    internal static IServiceCollection AddModule<TModule>(this IServiceCollection services, Action<Type, object> configureOptions)
        where TModule : IDiModule, new() => 
        new TModule()
            .SetCreaterConfigurationSection(configureOptions)
            .Registration(services);
}
