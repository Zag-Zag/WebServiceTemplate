using Serilog.Sinks.MSSqlServer;
using System.Data;

namespace ServiseLogger;

internal interface ILoggerParametrs
{
    string Layout { get; }
    int SizeParametrs { get; }
    MSSqlServerSinkOptions SinkOptions();
    ColumnOptions ColumnOptions();
    IEnumerable<SqlDbType> GetTypesForColumns();
}
