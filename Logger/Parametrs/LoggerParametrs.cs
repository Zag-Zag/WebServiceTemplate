using Serilog.Sinks.MSSqlServer;
using System.Data;

namespace ServiseLogger.Parametrs;

internal abstract class LoggerParametrs : ILoggerParametrs
{
    protected virtual bool AutoCreateSqlTable => false;
    abstract protected string TableName { get; }
    abstract protected SqlColumn[] Columns { get; }
    public string Layout => $"{{{string.Join("}{", Columns.Select(e => e.ColumnName))}}}";
    public int SizeParametrs => Columns.Length;
    public MSSqlServerSinkOptions SinkOptions() => new()
    {
        TableName = TableName,
        AutoCreateSqlTable = AutoCreateSqlTable
    };
    
    public ColumnOptions ColumnOptions()
    {
        var columnCollection = new ColumnOptions();
        columnCollection.Store.Clear();
        columnCollection.AdditionalColumns = Columns;
        return columnCollection;
    }
    protected static SqlColumn[] CreateSqlColumn(string[] columnNames) =>
        columnNames
            .Select(e => new SqlColumn 
            { 
                ColumnName = e
            })
            .ToArray();
    public IEnumerable<SqlDbType> GetTypesForColumns() =>
        Columns
            .Select(e => e.DataType);
}
