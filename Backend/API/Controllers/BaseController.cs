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
        else if (result.StatusCode == (int)HttpStatusCode.NoContent) return StatusCode((int)HttpStatusCode.NoContent, result.Message);
        else if (result.StatusCode == (int)HttpStatusCode.BadRequest) return BadRequest(result.Message);
        else if (result.StatusCode == (int)HttpStatusCode.Unauthorized) return Unauthorized(result.Message);
        else if (result.StatusCode == (int)HttpStatusCode.Forbidden) return Forbid(result.Message);
        else return StatusCode((int)HttpStatusCode.InternalServerError, result.Message);
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

        GetResult(response);

        return StatusCode(response.StatusCode, response);
    }
}
