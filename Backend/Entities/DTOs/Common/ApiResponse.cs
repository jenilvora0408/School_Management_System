namespace Entities.DTOs;

public class ApiResponse<T> : BaseResponse
{
    public T? Data { get; set; }
}



