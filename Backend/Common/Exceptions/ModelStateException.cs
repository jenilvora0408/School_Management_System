using Microsoft.AspNetCore.Mvc.ModelBinding;
using static Common.Constants.MessageConstants;

namespace Common.Exceptions;

public class ModelStateException : Exception
{
    public int StatusCode { get; set; }
    public List<string> Messages { get; set; }
    public Dictionary<string, object>? Metadata { get; set; }

    public ModelStateException(ModelStateDictionary modelState) : base(ErrorMessage.INVALID_MODELSTATE)
    {
        Messages = GetErrorMessages(modelState);
    }

    private static List<string> GetErrorMessages(ModelStateDictionary modelState)
    {
        List<string> message = new();

        if (modelState != null && modelState.Count > 0)
        {
            foreach (KeyValuePair<string, ModelStateEntry> item in modelState)
            {
                foreach (ModelError error in item.Value.Errors)
                {
                    message.Add(error.ErrorMessage);
                }
            }
        }
        return message;
    }
}
