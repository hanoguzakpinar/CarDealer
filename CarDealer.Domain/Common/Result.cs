namespace CarDealer.Domain.Common;
public class Result<T>
{
    public T Data { get; private set; }
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public List<string> Errors { get; private set; }

    public static Result<T> Success(T data, string message = null) => new Result<T> { IsSuccess = true, Data = data, Message = message };

    public static Result<T> Failure(string errorMessage) => new Result<T> { IsSuccess = false, Message = errorMessage, Errors = new List<string> { errorMessage } };
    public static Result<T> Failure(List<string> errors) => new Result<T> { IsSuccess = false, Errors = errors };
}

public class Result
{
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }

    public static Result Success(string message = null) => new Result { IsSuccess = true, Message = message };
    public static Result Failure(string message) => new Result { IsSuccess = false, Message = message };
}