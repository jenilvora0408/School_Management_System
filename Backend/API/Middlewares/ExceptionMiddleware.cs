using Common.Exceptions;
using Entities.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace API.Middlewares;

public class ExceptionMiddleware
{
    #region Constructors

    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    #endregion

    #region Methods

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            ApiResponse errorResponse = HandleException(error);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorResponse.StatusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse,
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            );
        }
    }

    #endregion

    #region Private_Methods

    private static ApiResponse HandleException(Exception error)
    {
        Console.WriteLine(error.Message);
        Console.WriteLine(error.StackTrace);

        ApiResponse errorResponse = new()
        {
            Message = error.InnerException?.Message ?? error.Message,
            StatusCode = error switch
            {
                CustomException ce => ce.StatusCode,
                ModelStateException mse => mse.StatusCode,
                _ => StatusCodes.Status500InternalServerError,
            }
        };

        if (error is ModelValidationException e)
        {
            errorResponse.Errors = e.Errors;
        }
        return errorResponse;
    }

    #endregion
}

