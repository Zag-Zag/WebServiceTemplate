
namespace ServiseLogger;

public interface IManagerLogger: IDisposable
{
    public IManagerLogger Error(params object[] value);
}
