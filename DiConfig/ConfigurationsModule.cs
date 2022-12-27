using AbstractDependencies.DiConfig;
using Microsoft.Extensions.DependencyInjection;
using Servises.Options;
using System;

namespace DiConfig;

internal class ConfigurationsModule : IDiConfigurationsModule
{

    public IServiceCollection Registration(IServiceCollection services, Action<Type, object> configureOptions) =>
        configureOptions != default
        ? services
            .Configure<ServiseConfiguration>(setting =>
            {
                configureOptions(typeof(ServiseConfiguration), setting);
            })
        : services;
}
