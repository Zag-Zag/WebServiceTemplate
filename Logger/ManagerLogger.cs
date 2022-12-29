using DataBaseEf.Configurations;
using Microsoft.Extensions.Options;
using ServiseLogger.Parametrs;

namespace ServiseLogger;

public class ManagerLogger: IManagerLogger, IDisposable
{
    private readonly Dictionary<Type, ILoggerContext> _loggers = new();

    private readonly Type _typeError = typeof(LoggerContext<ErrorParametrs>);

    public ManagerLogger(IOptions<ServiseLoggerConfiguration> config)
    {
        _loggers
            .Add(_typeError, new LoggerContext<ErrorParametrs>(config));
    }

    public IManagerLogger EnableDebugger()
    {
        foreach (var logger in _loggers)
        {
            logger.Value.EnableDebugger();
        }
        return this;
    }

    public IManagerLogger EnableDebugger(Action<string> debuggere)
    {
        foreach (var logger in _loggers)
        {
            logger.Value.EnableDebugger(debuggere);
        }
        return this;
    }

    public IManagerLogger Error(params object[] value)
    {
        if (!_loggers.TryGetValue(_typeError, out var logger))
        {
            throw new Exception();
        }
        logger.Log(value);
        return this;
    }

    public void Dispose()
    {
        foreach (var logger in _loggers)
        {
            logger.Value.Dispose();
        }
        GC.SuppressFinalize(this);
    }

}
