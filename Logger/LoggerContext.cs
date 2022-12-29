using DataBaseEf.Configurations;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Core;
using System.Data;
using System.Diagnostics;

namespace ServiseLogger;

internal class LoggerContext<TParametr> : ILoggerContext, IDisposable
    where TParametr : ILoggerParametrs, new()
{
    private readonly Logger _logger;
    private readonly TParametr _parametrs = new();

    public LoggerContext(IOptions<ServiseLoggerConfiguration> config)
    {
        _logger = new LoggerConfiguration()
            .WriteTo
            .MSSqlServer(
                connectionString: config.Value.ConnectionStrings,
                sinkOptions: _parametrs.SinkOptions(),
                columnOptions: _parametrs.ColumnOptions())
            .CreateLogger();
    }

    public ILoggerContext EnableDebugger() => EnableDebugger(msg => throw new Exception(msg));
    public ILoggerContext EnableDebugger(Action<string> debugger)
    {
        Serilog.Debugging.SelfLog.Enable(debugger);
        return this;
    }
    public ILoggerContext Log(params object[] values)
    {
        _logger.Information(_parametrs.Layout, СreateЬissingЗarameters(values));
        return this;
    }
    private object[] СreateЬissingЗarameters(object[] values)
    {
        if (values.Length >= _parametrs.SizeParametrs)
        {
            return values;
        }
        var frameCount = new StackTrace().FrameCount;

        var sqlDbTypes = _parametrs
            .GetTypesForColumns()
            .Skip(values.Length);

        return Enumerable.Range(0, _parametrs.SizeParametrs - values.Length)
            .Select(i => 
                sqlDbTypes
                    .Skip(i)
                    .Take(1)
                    .Select(e =>
                        e.Equals(SqlDbType.DateTime) || e.Equals(SqlDbType.Date)
                        ? DateTime.UtcNow
                        : e.Equals(SqlDbType.Int)
                        ? 0
                        : e.Equals(SqlDbType.NVarChar)
                        ? i + 2 < frameCount
                            ? new StackFrame(new StackTrace().FrameCount - (i + 2))
                                .GetMethod()?
                                .DeclaringType?
                                .FullName
                            : (object)string.Empty
                        : default)
            )
            .SelectMany(e => e)
            .ToArray();
    }

    public void Dispose()
    {
        _logger.Dispose();
        GC.SuppressFinalize(this);
    }
}