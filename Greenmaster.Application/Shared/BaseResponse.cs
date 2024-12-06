namespace Greenmaster.Application.Shared;

public class BaseResponse<T> where T : class 
{
    public bool Success { get; set; }
    
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public List<string>? ValidationErrors { get; set; } = [];
    
    public BaseResponse()
    {
        Success = true;
    }

    public BaseResponse(string message)
    {
        Success = false;
        Message = message;
    }
    
    public BaseResponse(string message, bool success)
    {
        Success = success;
        Message = message;
    }
}