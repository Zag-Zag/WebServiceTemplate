
using AbstractDependencies.DiConfig;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiConfig;

internal static class ExtensionIServiceCollection
{
    internal static IServiceCollection AddTransientDeligate<Interface, Realisation>(this IServiceCollection services)
        where Realisation : class, Interface
        where Interface : class =>
            services.AddTransient<Interface, Realisation>()
                .AddTransient(Func<Interface> (servicesProvider) => () => servicesProvider.GetRequiredService<Interface>());
    internal static IServiceCollection AddModule<TModule>(this IServiceCollection services)
        where TModule : IDiModuleBase, new() => new TModule().Registration(services);

    internal static IServiceCollection AddModule<TModule>(this IServiceCollection services, Action<Type, object> configureOptions)
        where TModule : IDiConfigurationsModule, new() =>
            configureOptions == default
            ? services
            : new TModule()
                .Registration(services, configureOptions);
}   
