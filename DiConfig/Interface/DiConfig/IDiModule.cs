
using System;

namespace AbstractDependencies.DiConfig;

public interface IDiModule : IDiModuleBase
{
    IDiModule SetCreaterConfigurationSection(Action<Type, object> configureOptions);
}
