namespace LeadManagement.Application.Models;

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }
    public object Value { get; }

    protected Result(bool isSuccess, string error, object value)
    {
        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }

    public static Result Success(object value = null)
    {
        return new Result(true, null, value);
    }

    public static Result Failure(string error)
    {
        return new Result(false, error, null);
    }
}

