namespace Hospital.BusinessLogic;

public class Result<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public static Result<T> Ok(T data)
    {
        Result<T> result = new Result<T>();
        result.Success = true;
        result.Data = data;
        result.Message = null;
        return result;
    }

    public static Result<T> Fail(string message)
    {
        Result<T> result = new Result<T>();
        result.Success = false;
        result.Data = default;
        result.Message = message;
        return result;
    }
}