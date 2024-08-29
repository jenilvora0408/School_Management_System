namespace Entities.DTOs;

public class ApiResponse
{
    public string Message { get; set; } = string.Empty;

    public bool Success
    {
        get
        {
            return StatusCode >= 200 && StatusCode <= 299;
        }
    }

    public object? Errors { get; set; }

    public object? Data { get; set; }

    public int StatusCode { get; set; }
}



