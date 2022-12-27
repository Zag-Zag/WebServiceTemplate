
using System;

namespace DataBaseEf.Repository;

public class ResultModel
{
    public ResultModel() { }
    
    public ResultModel(string exception) : this() => AddError(exception);
    public ResultModel(Exception exception) : this(exception.ToString()) { }

    public bool Error { get; private set; } = false;
    public string Message { get; private set; }

    public ResultModel AddError(Exception exception) => exception == default ? this : AddError(exception.ToString());
    public ResultModel AddError(string exception) => string.IsNullOrEmpty(exception) ? this : AddMessage(exception);

    private ResultModel AddMessage(string message)
    {
        Message += string.IsNullOrEmpty(Message) ? message : $"\n{message}";
        return this;
    }

}
