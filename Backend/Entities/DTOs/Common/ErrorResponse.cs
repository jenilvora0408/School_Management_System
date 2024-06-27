namespace Entities.DTOs;

public class ErrorResponse<T>
{
    public int StatusCode { get; set; }
    public List<string>? Messages { get; set; }

    public ErrorResponse(int statusCode, List<string>? messages)
    {
        StatusCode = statusCode;
        Messages = messages;
    }
}
