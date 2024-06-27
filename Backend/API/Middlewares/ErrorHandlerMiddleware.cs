
using System.Net;
using Common.Exceptions;
using Entities.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using static Common.Constants.MessageConstants;

namespace API.Middlewares
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            ErrorResponse<object> response = GenerateErrorResponse(context, ex);

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            string jsonResponse = JsonConvert.SerializeObject(response, serializerSettings);
            await context.Response.WriteAsync(jsonResponse);
        }

        private ErrorResponse<object> GenerateErrorResponse(HttpContext context, Exception ex)
        {
            List<string> messages = new();
            int httpStatusCode = (int)HttpStatusCode.InternalServerError;

            void AddStatusCodeAndMessage(int statusCode, List<string> message)
            {
                httpStatusCode = statusCode;
                messages.AddRange(message);
            }

            switch (ex)
            {
                case ModelStateException exception:
                    AddStatusCodeAndMessage((int)HttpStatusCode.BadRequest, exception.Messages);
                    break;
                case CustomException customException:
                    AddStatusCodeAndMessage(customException.StatusCode, customException.Messages);
                    break;
                default:
                    AddStatusCodeAndMessage((int)HttpStatusCode.InternalServerError, new List<string>() { ErrorMessage.INTERNAL_SERVER });
                    break;
            }
            context.Response.StatusCode = httpStatusCode;

            return new ErrorResponse<object>(httpStatusCode, messages);
        }
    }
}