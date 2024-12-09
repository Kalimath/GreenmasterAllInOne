namespace Greenmaster.Application.Shared;

public class ObjectResponse<T> where T : class 
{
    public bool Success { get; set; }
    
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public List<string>? ValidationErrors { get; set; } = [];
    
    public ObjectResponse()
    {
        Success = true;
    }

    public ObjectResponse(string message)
    {
        Success = false;
        Message = message;
    }
    
    public ObjectResponse(string message, bool success)
    {
        Success = success;
        Message = message;
    }
}