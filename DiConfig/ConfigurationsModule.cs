using AbstractDependencies.DiConfig;
using DataBaseEf.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Servises.Options;
using System;

namespace DiConfig;

internal class ConfigurationsModule : IDiConfigurationsModule
{

    public IServiceCollection Registration(IServiceCollection services, Action<Type, object> configureOptions) =>
        configureOptions == default
        ? services
        : services
            .Configure<ServiseConfiguration>(setting =>configureOptions(typeof(ServiseConfiguration), setting))
            .Configure<ServiseLoggerConfiguration>(setting => configureOptions(typeof(ServiseLoggerConfiguration), setting));
}
