using System.Net;
using Microsoft.AspNetCore.Mvc;
using Entities.DTOs;
using Common.Constants;

namespace API.Helpers;

public class ResponseHelper
{
    public static IActionResult CreatedResponse<T>(T? data, string message)
    {
        ApiResponse<T> result = new()
        {
            StatusCode = (int)HttpStatusCode.Created,
            Message = message,
            Data = data,
            Success = true,
        };
        return new ObjectResult(result) { StatusCode = (int)HttpStatusCode.Created };
    }

    public static IActionResult SuccessResponse<T>(T? data, string message = SystemConstants.SUCCESS)
    {
        ApiResponse<T> result = new()
        {
            StatusCode = (int)HttpStatusCode.OK,
            Message = message,
            Data = data,
            Success = true,
        };
        return new ObjectResult(result) { StatusCode = (int)HttpStatusCode.OK };

    }
}
