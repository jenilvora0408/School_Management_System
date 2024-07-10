using Common.Constants;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Common.Exceptions;

public class InvalidModelStateException : Exception
{
    public int StatusCode { get; set; }
    public List<string> Messages { get; set; }
    public Dictionary<string, object>? Metadata { get; set; }

    public InvalidModelStateException(ModelStateDictionary modelState)
        : base(GetFirstErrorMessage(modelState))
    {
        StatusCode = (int)HttpStatusCode.BadRequest;

        Messages = GetErrorMessages(modelState);
    }

    private static string GetFirstErrorMessage(ModelStateDictionary modelState)
    {
        if (modelState != null && modelState.Count > 0)
        {
            ModelError firstError = modelState.Values.First().Errors.FirstOrDefault();
            if (firstError != null)
            {
                return firstError.ErrorMessage;
            }
        }

        return MessageConstants.ErrorMessage.INVALID_MODELSTATE;
    }

    private static List<string> GetErrorMessages(ModelStateDictionary modelState)
    {
        List<string> message = new();

        if (modelState != null && modelState.Count > 0)
        {

            foreach (var keyValuePair in modelState)
            {
                var errors = new List<string>();
                foreach (var error in keyValuePair.Value.Errors)
                {
                    message.Add(error.ErrorMessage);
                }
            }
        }
        return message;
    }
}
