using Common.Constants;
using Entities.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementAPI.Helpers
{
    public class ResponseHelper
    {
        public static IActionResult CreateResourceResponse(object? data, string message = MessageConstants.GLOBAL_CREATED)
        {
            ApiResponse response = new()
            {
                StatusCode = StatusCodes.Status201Created,
                Message = message,
                Data = data,
                Success = true
            };

            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        public static IActionResult SuccessResponse(object? data, string message = MessageConstants.GLOBAL_SUCCESS)
        {
            ApiResponse response = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = message,
                Data = data,
                Success = true
            };
            return new ObjectResult(response) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
