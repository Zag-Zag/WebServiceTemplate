
namespace ServiseLogger;

internal interface ILoggerContext: IDisposable
{
    public ILoggerContext EnableDebugger();
    public ILoggerContext EnableDebugger(Action<string> debugger);
    public ILoggerContext Log(params object[] values);
}
