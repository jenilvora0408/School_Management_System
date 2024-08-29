using System.Net;
using Common.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected IActionResult GetResult(ApiResponse result)
    {
        if (result.Success && result.StatusCode == (int)HttpStatusCode.OK) return Ok(result);
        else if (result.StatusCode == (int)HttpStatusCode.NotFound) return NotFound(result.Message);
        else return BadRequest(result.Message);
    }

    protected IActionResult GetResult(object? data, string? message, HttpStatusCode statusCode = HttpStatusCode.OK, object? errors = null)
    {
        ApiResponse response = new ApiResponse
        {
            Data = data,
            Errors = errors,
            StatusCode = (int)statusCode,
            Message = message ?? SystemConstants.SUCCESS
        };

        if (errors != null)
        {
            response.Message = errors.ToString() ?? MessageConstants.ErrorMessage.DEFAULT_ERROR_MESSAGE;
        }

        return StatusCode(response.StatusCode, response);
    }
}
