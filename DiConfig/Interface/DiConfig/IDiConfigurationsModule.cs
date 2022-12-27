using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AbstractDependencies.DiConfig;

public interface IDiConfigurationsModule
{
    IServiceCollection Registration(IServiceCollection services, Action<Type, object> configureOptions);
}
