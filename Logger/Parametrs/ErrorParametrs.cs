using Serilog.Sinks.MSSqlServer;
using System.Data;

namespace ServiseLogger.Parametrs;

internal class ErrorParametrs : LoggerParametrs
{
    protected override string TableName => throw new NotImplementedException();
    protected override SqlColumn[] Columns => new SqlColumn[]
    {
        new SqlColumn
        {
            ColumnName = "Message",
            DataType =  SqlDbType.NVarChar,
            AllowNull = false,
        },
        new SqlColumn
        {
            ColumnName = "Sourse",
            DataType =  SqlDbType.NVarChar,
            DataLength = 100,
            AllowNull = false,
            NonClusteredIndex = true,
        },
        new SqlColumn
        {
            ColumnName = "Date",
            DataType =  SqlDbType.DateTime,
            AllowNull = false,
            NonClusteredIndex = true,
        }
    };
}
