namespace Entities.DTOs.Response
{
    public class ApiResponse
    {
        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; }

        public object? Errors { get; set; }

        public object? Data { get; set; }

        public int StatusCode { get; set; }
    }
}
